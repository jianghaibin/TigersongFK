//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a Tigersong Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
//     Author:Haibin Jiang
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Configuration;

using Autofac;
using Autofac.Configuration;
using Autofac.Configuration.Elements;
using Autofac.Builder;

using Tigersong.Common;
using Tigersong.AOPProxy;
using Tigersong.IServices;

namespace Tigersong.ServiceProvider
{
	/// <summary>
	/// 配置实现服务接口
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Instance<T> where T : IService
	{
		private static object _locker = new object();

		private static Hashtable _serviceProviders = new Hashtable();

		/// <summary>
		/// 创建接口实例
		/// </summary>
		public static T Create
		{
			get
			{
				T t;
				ContainerBuilder containerBuilder = new ContainerBuilder();
				ConfigurationSettingsReader configurationSettingsReader = new ConfigurationSettingsReader("autofac");
				ComponentElement componentElement = configurationSettingsReader.SectionHandler.Components.FirstOrDefault((ComponentElement item) => item.Service.Contains(typeof(T).FullName));
				try
				{
					if (componentElement != null)
					{
						containerBuilder.RegisterType<T>();
						containerBuilder.RegisterModule(configurationSettingsReader);
					}
					else
					{
						string instanceName = typeof(T).Name;
						string instanceFullName = typeof(T).FullName;
						string str = instanceFullName.Substring(0, instanceFullName.LastIndexOf('.'));
						var strServiceProviders = GetServiceProviders(str);
						if (strServiceProviders == null)
						{
							throw new ApplicationException(string.Concat("未配置服务接口", instanceFullName, "的实现"));
						}
						char[] chrArray = new char[] { ',' };
						string strAssembly = strServiceProviders.Split(chrArray)[0];
						string strNamespace = strServiceProviders.Split(chrArray)[1];
						string strServiceName = instanceName.Substring(1);
						string strServiceProviderName = string.Format("{0}.{1}, {2}", strAssembly, strServiceName, strNamespace);
						Type type = Type.GetType(strServiceProviderName);
						if (type == null)
						{
							throw new NotImplementedException(string.Concat("未找到服务", strServiceProviderName));
						}
						containerBuilder.RegisterType(type).As<T>();
					}
					//创建实例
					T IContainer = containerBuilder.Build(ContainerBuildOptions.None).Resolve<T>();
					//是否使用AOP代理
					string strIsAopProxy = ConfigurationManager.AppSettings["IsAopProxy"];
					t = (string.IsNullOrEmpty(strIsAopProxy) || !Convert.ToBoolean(strIsAopProxy) ? IContainer : (T)(new AopProxy<T>(IContainer)).GetTransparentProxy());
				}
				catch (Exception ex)
				{
					throw new TsException(string.Concat(typeof(T).Name, "服务实例创建失败"), ex);
				}
				return t;
			}
		}

		/// <summary>
		/// 获取服务提供者
		/// </summary>
		private static string GetServiceProviders(string key)
		{
			if (_serviceProviders?[key] == null)
			{
				lock (_locker)
				{
					if (_serviceProviders?[key] == null)
					{
						foreach (Item item in (ConfigurationManager.GetSection("serviceProvider") as ServiceProviderConfig).Items)
						{
							if (_serviceProviders.ContainsKey(item.Interface))
							{
								continue;
							}
							_serviceProviders.Add(item.Interface, string.Concat(item.NameSpace, ",", item.Assembly));
						}
					}
				}
			}

			return _serviceProviders?[key].ToString();
		}

	}
}

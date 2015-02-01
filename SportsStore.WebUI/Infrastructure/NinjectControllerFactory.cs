﻿using Moq;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI.Infrastructure
{
	public class NinjectControllerFactory : DefaultControllerFactory
	{
		private IKernel _ninjectKernel;

		public NinjectControllerFactory()
		{
			_ninjectKernel = new StandardKernel();
			addBindings();
		}

		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			return controllerType == null 
				? null
				: (IController)_ninjectKernel.Get(controllerType);
		}

		private void addBindings()
		{
			_ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
		}
	}
}
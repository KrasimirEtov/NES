﻿using NES.Core.Commands.Contracts;
using NES.Core.Engine.Contracts;
using NES.Entities.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NES.Core.Engine
{
	public class Engine
	{
		private static readonly Engine SingleInstance = new Engine();

		// private readonly IMarket market;
		// private readonly IUser user;
		private readonly IFactory factory;

		private Engine()
		{
			//this.market = Market.Instance;
			this.factory = AssetFactory.Instance;
		}

		public static Engine Instance
		{
			get => SingleInstance;
		}

	}

}

﻿using NES.Entities.Users.Contracts;

namespace NES.Entities.Broker.Contracts
{
	public interface IBroker
	{
		void EndDayTraiding();
		void BuyBTC(decimal amount, IUser user);
		void BuyETH(decimal amount, IUser user);
		void BuyLitecoin(decimal amount, IUser user);
		void BuyGold(decimal amount, IUser user);
		void BuySilver(decimal amount, IUser user);
		void BuyPlatinum(decimal amount, IUser user);
		void BuyGoogleStock(decimal amount, IUser user);
		void BuyFacebookStock(decimal amount, IUser user);
		void BuyNetflixStock(decimal amount, IUser user);
	}
}

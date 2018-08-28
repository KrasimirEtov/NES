# First teamwork project for Telerik Academy Alpha .NET Jul' 18

## Team members
- **N** Алекс Никлев - https://my.telerikacademy.com/Users/alex.bul.10
- **E** Красимир Етов - https://my.telerikacademy.com/Users/MESA1997
- **S** Йоан Ставрев - https://my.telerikacademy.com/Users/j0nze

## About
NES Market is all about sales. It's basically a Wall Street simulator.

## Quick info
To begin user must register or login if he/she already have a registered account.
After that he/she can start buying/selling assets to become the Wolf of Wall Street.

## Available commands

- **register** [userName] [password] [cash] => registers a new user
- **login** [userName] [password] => logs the user
- **buy** [assetName] [amount] => allows the user to buy assets
- **sell** [assetName] [amount] => allows the user to sell assets
- **logout** => logouts the user
- **printwallet** => prints the user wallet
- **exit** => shuts down the program

## Available assets
**Crypto currencys:**


- bitcoin
- ethereum
- litecoin

**Precious metals**


- gold
- platinum
- silver

**Stocks**


- facebook
- google
- netflix

## What problems did the application have before you started refactoring?

Bad use of Singelton pattern and a switch/case, which was breaking the Open/Closed principle. Before adding a container, classes were responsible for initializing their own dependency, which is a bad practice.


## What design patterns have you used and why?

Command pattern – to deal with the commands, helps us follow the Open/Closed principle and allows us to lower the coupling.

Factory pattern – takes care of the creating of our objects, helps us follow the dependency inversion principle.


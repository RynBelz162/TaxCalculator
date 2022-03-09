# 🧮 TaxCalculator

This Xamarin Forms app uses the TaxJar API to calculate the tax rate for a specified location and the tax to collect for an order.

### Things I would improve with more time
- I would most likely add some form of local caching for location rates.
- I would like to incorporate a nicer loading animation.
- I would like to improve the result UI instead of just displaying a label.

### Some issues I noticed that I would fix with more time
- Calculating an order tax between two states returns 0 sometimes. Not sure if this is correct or maybe I am calling TaxJar wrong.
- The disabled button on the order page does not calculate the amount and shipping validation correctly sometimes.

## 💻 Tech Used
- [Xamarin Forms](https://www.nuget.org/packages/Xamarin.Forms/)
- [Xamarin Community Toolkit](https://www.nuget.org/packages/Xamarin.CommunityToolkit/)
- [Refractored.MvvmHelpers](https://www.nuget.org/packages/Refractored.MvvmHelpers/)
- [Microsoft Extensions Dependency Injection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/)

## 📸 Screenshots

![image android1](./Screenshots/android1.png)
![image android2](./Screenshots/android2.png)
![image iphone1](./Screenshots/iPhone1.png)
![image iphone2](./Screenshots/iPhone2.png)
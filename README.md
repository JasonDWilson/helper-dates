# jwPro Date Helpers

*This project contains of number of date related helper functions and extension methods.*

## Current primary functions:
- identify special dates or holidays
- business related functions

### To use helper functions:
1. Add a reference **helper-dates**
2. Add the namespace directive:
```csharp
using jwpro.DateHelper.Enums;
using jwpro.DateHelper.Helpers;
```
3. Call methods using the **SpecialDateHelper** static class
- **GetChristmasDay**
- **GetChristmasEve**
- **GetColumbusDay**
- **GetIndependenceDay**
- **GetLaborDay**
- **GetMartinLutherKingJrDay**
- **GetMemorialDay**
- **GetNewYearsDay**
- **GetNewYearsEve**
- **GetPresidentsDay**
- **GetSpecialDate**
- **GetThanksgivingDay**
- **GetThanksgivingDayAfter**
- **GetVeteransDay**
- **IsChristmasDay**
- **IsChristmasEve**
- **IsColumbusDay**
- **IsIndependenceDay**
- **IsLaborDay**
- **IsMartinLutherKingJrDay**
- **IsMemorialDay**
- **IsNewYearsDay**
- **IsNewYearsEve**
- **IsPresidentsDay**
- **IsSpecialDate**
- **IsThanksgivingDay**
- **IsThanksgivingDayAfter**
- **IsVeteransDay**
- **IsWeekday**
- **IsWeekend**

### To use extension methods:
1. Add a reference **helper-dates**
2. Add the namespace directive:
```csharp
using jwpro.DateHelper.Enums;
using jwpro.DateHelper.Extensions;
```
3. Call extension methods from any DataTime variable
- **IsChristmasDay**
- **IsChristmasEve**
- **IsColumbusDay**
- **IsIndependenceDay**
- **IsLaborDay**
- **IsMartinLutherKingJrDay**
- **IsMemorialDay**
- **IsNewYearsDay**
- **IsNewYearsEve**
- **IsPresidentsDay**
- **IsSpecialDate**
- **IsThanksgivingDay**
- **IsThanksgivingDayAfter**
- **IsVeteransDay**
- **IsWeekday**
- **IsWeekend**

### To use Business Date Manager
1. Add a reference **helper-dates**
2. Add the namespace directive:
```csharp
using jwpro.DateHelper.Configuration;
using jwpro.DateHelper.Managers;
```
3. The constructor for **BusinessDateManager** expects an instance of **BusinessDateManagerConfiguration** to be injected
4. This can be accomplished by adding at **BusinessDateManagerConfiguration** section to your *appsettings.json* file like this:
```json
"BusinessDateManagerConfiguration": {
	"BusinessDayBegin": "08:00",
	"BusinessDayEnd":  "17:00",
	"PaidHolidays": [
		{
			"AssociatedSpecialDate": "Christmas_Day"
		},
		{
			"Name": "Christmas Eve",
			"RelatedSpecialDate": "Christmas_Day",
			"RelatedSpecialDateOffset": -1
		},
		{
			"AssociatedSpecialDate": "Independence_Day"
		},
		{
			"AssociatedSpecialDate": "Labor_Day"
		},
		{
			"AssociatedSpecialDate": "Memorial_Day"
		},
		{
			"Name": "New Years Eve",
			"RelatedSpecialDate": "New_Years_Day",
			"RelatedSpecialDateOffset": 365
		},
		{
			"AssociatedSpecialDate": "New_Years_Day"
		},
		{
			"AssociatedSpecialDate": "Thanksgiving_Day"
		},
		{
			"Name": "Day After Thanksgiving",
			"RelatedSpecialDate": "Thanksgiving_Day",
			"RelatedSpecialDateOffset": 1
		},
		{
			"Name": "Jasons Birthday",
			"DateCalculationString": "(string year) => new DateTime(Int16.Parse(year), 12, 21)"
		}
	]
}
```
- The **PaidHoliday** class expects either
	- An **AssociatedSpecialDate** that matches a value on the **SpecialDate** enum or
	- A **Name** and a **RelatedSpecialDate** with an appropriate **RelatedSpecialDateOffset** or
	- A **Name** and a **DateCalculation**
		- **DateCalculation** can be declared in json using **DateCalculationString**
5. The values can **BusinessDateManagerConfiguration** can be configured to be injected in the **BusinessDateManager** like this:
```csharp
  _config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
  _businessConfig = new BusinessDateManagerConfiguration();
  _config.GetSection("BusinessDateManagerConfiguration").Bind(_businessConfig);
  _services.AddSingleton<BusinessDateManagerConfiguration>(_businesConfig);
```
6. Use to BusinessDateManager to do the following:
- Determine if a date is a **PaidHoliday**:
```csharp
   var actual = _manager.IsPaidHoliday(inputDate);
```
- Get the number of business hours between 2 dates:
```csharp
    double actual = _manager.GetBusinessHours(beginDate, endDate);
```
- Get the date a specific **PaidHoliday**
```csharp
    var paidHoliday = _manager.PaidHolidays.FirstOrDefault(x => x.AssociatedSpecialDate == SpecialDate.Thanksgiving_Day);
    DateTime thanksgiving = paidHoliday.GetDate(year: "2020"); 
```
- Other Functions:
	- **GetPaidHolidayDate**

*Would love for others to contribute*

*If you have any questions - drop me a note*

Jason Wilson

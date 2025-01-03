## ZO Blazor Persian Date Picker
This Date picker is a blazor component written using C# only and no javascript. This date picker only works with jalali calender.
We created this component for the personal use but we decided to publish it on github for other people that feel the need for a persian date picker 
component like us. Note that we didn't use culture in this calender since it was going to be used only for the jalali/persian calender. 

![PersianDatePicker](https://raw.githubusercontent.com/AliRoostae/Blazor_PersianDatePickerZO/master/img/PersianDatePicker.jpg) | ![PersianDatePicker](https://raw.githubusercontent.com/AliRoostae/Blazor_PersianDatePickerZO/master/img/changeClock.gif) |


## Prerequisites
- [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) 


 

### Quick Installation Guide
[Install Package](https://www.nuget.org/packages/Blazor_PersianDatePickerZO/ "nuget")
```
Install-Package Blazor_PersianDatePickerZO
```

Add the following link to `index.html` (client-side) or `_Host.cshtml` (server-side) in the `head`
```
<link href="_content/Blazor_PersianDatePickerZO/AppDatePickerZeroOne.css" rel="stylesheet" />
```
```
<script src="_content/Blazor_PersianDatePickerZO/AppDatePickerZeroOne.js"></script>
```

Add the following imports to `_Imports.razor`
```
@using Blazor_PersianDatePickerZO.Component
@using Blazor_PersianDatePickerZO.Hellper
```

## Usage
### Date Picker Usage 
```
< DatePickerZO PupupDatePickerZO="true OR false" @bind-SelectDate="@value">

@code {
  public DateTime value { get; set; } 
}
```

### Range Date Picker Usage 
```
<DatePickerZORange SelectDateFirst="@dateFirst" SelectDateLast="@dateLast"  />

@code {
  public DateTime dateFirst { get; set; } 
  public DateTime dateLast { get; set; } 
}
```

### Theming
use one of the following enum members to change the theme of the date picker
```
< DatePickerZO ThemePickerZO="ThemeDatePickerZO.darkblue">
```
```
enum ThemeDatePickerZO
{
   lightgreen,
   lightred,
   lightblue,
   lightpurple,
   lightorange,
   lightgray,
   darkgreen,
   darkred,
   darkblue,
   darkpurple,
   darkorange,
   darkgray    
}
```


### Individual Modules  
The main date picker consists of multiple components and the components can be used individualy like the samples below
#### Time Only
There are 2 different time picker components with different looks that can be used in different scenarios 
```
 <TimeZO   @bind-SelectDate="@value"/>
<ClockZO  @bind-SelectDate="@value" />
```

#### Day Only
```
<DayZO  @bind-SelectDate="@value" />
```



#### year and month
```
<YearMonthZO   @bind-SelectDate="@value" />
```

#### chang format
Format="TypeFormat"
yyyy/MM/dd  Or  yy/MM/dd  Or  MMM  Or ddd Or ..
```
<DatePickerZO  Format="ddd D MMM سال yyyy ساعت hh:mm:ss"  />
```




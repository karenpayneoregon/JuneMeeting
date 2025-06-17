using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplesApp.Models;

internal class Person
{
}

public class Address
{
    public int AddressIdentifier { get; set; }
}

public class Country
{
    public int CountryIdentifier { get; set; }
    public string Name { get; set; } = null!;
}

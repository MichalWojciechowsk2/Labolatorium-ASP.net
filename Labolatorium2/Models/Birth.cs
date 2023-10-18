using System;

public class Birth
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }

    public bool IsValid()
    {
        return !string.IsNullOrEmpty(Name) && BirthDate < DateTime.Now;
    }

    public int CalculateAge()
    {
        int age = DateTime.Now.Year - BirthDate.Year;
        if (DateTime.Now.DayOfYear < BirthDate.DayOfYear)
        {
            age--;
        }
        return age;
    }
}
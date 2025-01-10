public class PersonalNumberValidator
{
    //tar bort eventuella bindestreck och mellanslag
    public string CleanPersonalNumber(string persNumber)
    {
        return persNumber.Replace("-", "").Replace(" ", "");
    }

}
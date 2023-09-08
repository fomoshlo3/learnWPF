namespace XAMLDataBinding.OneWay.Models
{
    public class Employees
    {
        public string Name { get; set; }
        public string Title { get; set; }

        public static Employees GetEmployees()
        {
            var emp = new Employees() { Name = "Hannes Kasel", Title = "Developer" };
            return emp;
        }
    }
}
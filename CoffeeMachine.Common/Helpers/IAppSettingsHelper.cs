namespace CoffeeMachine.Common.Helpers
{
    public interface IAppSettingsHelper
    {
        int GetCappuccinoRequiredBeans();
        int GetCappuccinoRequiredMilk();
        int GetCoffeeRequiredBeans();
        int GetCoffeeRequiredMilk();
        int GetLatteRequiredBeans();
        int GetLatteRequiredMilk();
        int GetTotalMachineBeans();
        int GetTotalMachineMilk();
    }
}
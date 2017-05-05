using XamarinLocalDataAccessDemo.Demos;
using XamarinLocalDataAccessDemo.Droid.Demos;

[assembly:Xamarin.Forms.Dependency(typeof(SecureDataDemo))]
namespace XamarinLocalDataAccessDemo.Droid.Demos
{
    
    public class SecureDataDemo : ISecureDataDemo
    {
        //private AccountStore _accountStore;
        private string _key = "myKey";
        public SecureDataDemo()
        {
            //_accountStore = AccountStore.Create(Forms.Context);
        }
        public string GetSecureData()
        {
            //var account = _accountStore.FindAccountsForService("XamarinLocalDataAccessDemo").FirstOrDefault();
            //return account?.Properties["SecureData"];
            return string.Empty;
        }

        public void SaveSecureData(string value)
        {
            //var account = new Account(_key);
            //account.Properties.Add("SecureData", value);
            //_accountStore.Save(account, "XamarinLocalDataAccessDemo");
        }
    }
}
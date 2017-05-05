using System.Diagnostics;
using Foundation;
using Security;
using XamarinLocalDataAccessDemo.Demos;
using XamarinLocalDataAccessDemo.iOS.Demos;

[assembly:Xamarin.Forms.Dependency(typeof(SecureDataDemo))]
namespace XamarinLocalDataAccessDemo.iOS.Demos
{
    public class SecureDataDemo : ISecureDataDemo
    {
        private string _key = "myKey";

        public string GetSecureData()
        {
            var record = GetExistingRecordForKey(_key);
            SecStatusCode resultCode;
            var match = SecKeyChain.QueryAsRecord(record, out resultCode);

            return resultCode == SecStatusCode.Success ? 
                NSString.FromData(match.ValueData, NSStringEncoding.UTF8) 
                : string.Empty;
        }

        public void SaveSecureData(string value)
        {
            var record = GetExistingRecordForKey(_key);
            if (!string.IsNullOrEmpty(GetSecureData()))
            {
                SecKeyChain.Remove(record);
            }
            var resultCode = SecKeyChain.Add(CreateRecordForKey(_key, value));
            if (resultCode != SecStatusCode.Success)
            {
                Debug.WriteLine(resultCode);
            }
        }



        private SecRecord GetExistingRecordForKey(string key)
        {
            var record =  new SecRecord(SecKind.GenericPassword)
            {
                Account = key,
                Service = "XamarinLocalDataAccessDemo",
                Label = key,
            };
            return record;
        }

        private SecRecord CreateRecordForKey(string key, string value)
        {
            var record =  new SecRecord(SecKind.GenericPassword)
            {
                Account = key,
                Service = "XamarinLocalDataAccessDemo",
                Label = key,
                ValueData = NSData.FromString(value, NSStringEncoding.UTF8)
            };
            return record;
        }

    }
}
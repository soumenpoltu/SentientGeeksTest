using MyHelping.Section.interfaces;
using System.Text;

namespace MyHelping.Section.Conversion
{
    public class Encryption : IEncryption
    {

        public String Encryptdata(String strText)
        {
            byte[] EncodeAsBytes = Encoding.UTF8.GetBytes(strText);
            String returnValue = System.Convert.ToBase64String(EncodeAsBytes);
            return returnValue;
        }

        public String Decryptdata(String strText)
        {
            byte[] DecodeAsBytes = System.Convert.FromBase64String(strText);
            String returnValue = Encoding.UTF8.GetString(DecodeAsBytes);
            return returnValue;
        }



    }
}

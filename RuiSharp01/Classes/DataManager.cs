using System.Collections.Generic;
using System.Linq;
using RuiSharp01.Enums;

namespace RuiSharp01.Classes
{
    public class DataManager
    {
        public int LENGTH_LIMIT { get; private set; } = 10;
        private List<string> _data = new List<string>();

        public RegisterStatus RegisterData(string data)
        {
            if (data == string.Empty) return RegisterStatus.EmptyValueFailed;
            if (data.Length > LENGTH_LIMIT) return RegisterStatus.LengthOverFailed;
            _data.Add(data);
            return RegisterStatus.Succesed;
        }

        public void ClearData()
        {
            _data.Clear();
        }
        
        public string OutputText(string delimiter = ",")
        {
            if (_data.Count == 0) return string.Empty;
            return string.Join(delimiter, _data);
        }
    }
}
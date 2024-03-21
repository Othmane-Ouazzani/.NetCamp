using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MaterialDesign
{
    public class SwitchResources : ResourceDictionary
    {
        private Uri? first;
        private Uri? second;
        private bool isFirst;

        public Uri? First
        {
            get => first;
            set
            {
                if (Equals(first, value))
                    return;
                first = value;
                if (!IsFirst)
                    return;
                if (value is not null)
                    Source = value;
            }
        }
        public Uri? Second
        {
            get => second;
            set
            {
                if (Equals(second, value))
                    return;
                second = value;
                if (IsFirst)
                    return;
                if (value is not null)
                    Source = value;
            }
        }

        public bool IsFirst
        {
            get => isFirst;
            set
            {
                if (isFirst == value)
                    return;
                isFirst = value;
                if (IsFirst)
                {
                    if (First is not null)
                        Source = First;
                }
                else
                {
                    if (Second is not null)
                        Source = Second;
                }
            }
        }

        public static void SetIsFirst(bool isFirst)
        {
            SwitchResources? switchResources = Application.Current.Resources.MergedDictionaries.OfType<SwitchResources>().FirstOrDefault();
            if (switchResources is not null)
            {
                switchResources.IsFirst = isFirst;
            }
        }
    }
}

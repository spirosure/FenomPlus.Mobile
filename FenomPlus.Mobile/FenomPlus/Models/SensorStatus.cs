using System;
using Xamarin.Forms;

namespace FenomPlus.Models
{
    public class SensorStatus : BaseModel
    {
        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        private ImageSource image;
        public ImageSource Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        private string value;
        public string Value
        {
            get => value;
            set
            {
                this.value = value;
                OnPropertyChanged("Value");
            }
        }

        private string type;
        public string Type
        {
            get => type;
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }

        private string description;
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        private Color color;
        public Color Color
        {
            get => color;
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }

        private int rawValue;
        public int RawValue
        {
            get => rawValue;
            set
            {
                rawValue = value;
                OnPropertyChanged("RawValue");
            }
        }
    }
}

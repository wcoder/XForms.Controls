using System;
using System.Collections;
using Xamarin.Forms;

namespace XFormsControls.Controls
{
    public class ListPicker : Picker
    {
        public static BindableProperty ConverterProperty =
               BindableProperty.Create<ListPicker, IValueConverter>(o => o.Converter,
                   default(IValueConverter), BindingMode.TwoWay, null,
                   null, null, null);

        public static BindableProperty ItemsSourceProperty =
                BindableProperty.Create<ListPicker, IEnumerable>(o => o.ItemsSource,
                    default(IEnumerable), BindingMode.OneWay, null,
                    new BindableProperty.BindingPropertyChangedDelegate<IEnumerable>(OnItemsSourceChanged), null, null);

        public static BindableProperty SelectedItemProperty =
                BindableProperty.Create<ListPicker, object>(o => o.SelectedItem,
                    default(object), BindingMode.TwoWay, null,
                    new BindableProperty.BindingPropertyChangedDelegate<object>(OnSelectedItemChanged), null, null);

        public IValueConverter Converter
        {
            get { return (IValueConverter)GetValue(ConverterProperty); }
            set { SetValue(ConverterProperty, value); }
        }

        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public ListPicker()
        {
            SelectedIndexChanged += OnSelectedIndexChanged;
        }

        private static void OnItemsSourceChanged(BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
        {
            try
            {
                var picker = bindable as ListPicker;
                picker.Items.Clear();
                if (newvalue != null)
                {
                    foreach (var item in newvalue)
                    {
                        picker.Items.Add(picker.Convert(item, picker.Converter));
                    }
                }
            }
            catch
            { //To solve navigation issues
            }
        }

        private string Convert(object input, IValueConverter converter)
        {
            return converter == null
                            ? input.ToString()
                            : (string)converter.Convert(input, typeof(string), null, System.Globalization.CultureInfo.CurrentUICulture);
        }

        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
            {
                SelectedItem = null;
            }
            else
            {
                SelectedItem = ItemsSource[SelectedIndex];
            }
        }
        private static void OnSelectedItemChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as ListPicker;
            if (newvalue != null)
            {
                picker.SelectedIndex = picker.ItemsSource.IndexOf(newvalue);
            }
        }
    }
}

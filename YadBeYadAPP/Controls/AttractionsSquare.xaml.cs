using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YadBeYadApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AttractionsSquare : ContentView
    {
      public AttractionsSquare()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty BusinessNameProperty = BindableProperty.Create(
        "BusinessName",        // the name of the bindable property
        typeof(string),     // the bindable property type
        typeof(AttractionsSquare),   // the parent object type
        string.Empty);      // the default value for the property

        public static readonly BindableProperty BusinessCategoryProperty = BindableProperty.Create(
        "BusinessCategory",        // the name of the bindable property
        typeof(string),     // the bindable property type
        typeof(AttractionsSquare),   // the parent object type
        string.Empty);      // the default value for the property

        public static readonly BindableProperty BusinessImageUrlProperty = BindableProperty.Create(
        "BusinessImageUrl",        // the name of the bindable property
        typeof(string),     // the bindable property type
        typeof(AttractionsSquare),   // the parent object type
        string.Empty);      // the default value for the property

        public static readonly BindableProperty BusinessCommandProperty = BindableProperty.Create(
        "BusinessCommand",        // the name of the bindable property
        typeof(ICommand),     // the bindable property type
        typeof(AttractionsSquare),   // the parent object type
        null);      // the default value for the property

        //public static readonly BindableProperty BusinessCommandParameterProperty = BindableProperty.Create(
        //"BusinessCommandParameter",        // the name of the bindable property
        //typeof(string),     // the bindable property type
        //typeof(BusinessCardView),   // the parent object type
        //string.Empty);      // the default value for the property

        public static readonly BindableProperty BusinessIdProperty = BindableProperty.Create(
        "BusinessId",        // the name of the bindable property
        typeof(string),     // the bindable property type
        typeof(AttractionsSquare),   // the parent object type
        string.Empty);      // the default value for the property

        public string BusinessName
        {
            get => (string)GetValue(BusinessNameProperty);
            set => SetValue(BusinessNameProperty, value);
        }

        public string BusinessCategory
        {
            get => (string)GetValue(BusinessCategoryProperty);
            set => SetValue(BusinessCategoryProperty, value);
        }

        public string BusinessImageUrl
        {
            get => (string)GetValue(BusinessImageUrlProperty);
            set => SetValue(BusinessImageUrlProperty, value);
        }

        public ICommand BusinessCommand
        {
            get => (ICommand)GetValue(BusinessCommandProperty);
            set => SetValue(BusinessCommandProperty, value);
        }

        //public string BusinessCommandParameter
        //{
        //    get => (string)GetValue(BusinessCommandParameterProperty);
        //    set => SetValue(BusinessCommandParameterProperty, value);
        //}

        public string BusinessId
        {
            get => (string)GetValue(BusinessIdProperty);
            set => SetValue(BusinessIdProperty, value);
        }

    }
}
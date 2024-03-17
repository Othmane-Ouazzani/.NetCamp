using DataGridExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaterialDesign
{
    /// <summary>
    /// Interaction logic for FilterWithPopupControl.xaml
    /// </summary>
    public partial class FilterWithPopupControl
    {
        public FilterWithPopupControl()
        {
            InitializeComponent();
        }

        public string Caption
        {
            get => (string)GetValue(CaptionProperty);
            set => SetValue(CaptionProperty, value);
        }
        /// <summary>
        /// Identifies the Minimum dependency property
        /// </summary>
        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register(nameof(Caption), typeof(string), typeof(FilterWithPopupControl)
                , new FrameworkPropertyMetadata("Enter the limits:", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public double Minimum
        {
            get => (double)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }
        /// <summary>
        /// Identifies the Minimum dependency property
        /// </summary>
        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register(nameof(Minimum), typeof(double), typeof(FilterWithPopupControl)
                , new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (sender, _) => ((FilterWithPopupControl)sender).Range_Changed()));

        public double Maximum
        {
            get => (double)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }
        /// <summary>
        /// Identifies the Maximum dependency property
        /// </summary>
        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register(nameof(Maximum), typeof(double), typeof(FilterWithPopupControl)
                , new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (sender, _) => ((FilterWithPopupControl)sender).Range_Changed()));


        public bool IsPopupVisible
        {
            get => (bool)GetValue(IsPopupVisibleProperty);
            set => SetValue(IsPopupVisibleProperty, value);
        }
        /// <summary>
        /// Identifies the IsPopupVisible dependency property
        /// </summary>
        public static readonly DependencyProperty IsPopupVisibleProperty =
            DependencyProperty.Register(nameof(IsPopupVisible), typeof(bool), typeof(FilterWithPopupControl), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        private void Range_Changed()
        {
            Filter = Maximum > Minimum ? new ContentFilter(Minimum, Maximum) : null;
        }

        public IContentFilter? Filter
        {
            get => (IContentFilter?)GetValue(FilterProperty);
            set => SetValue(FilterProperty, value);
        }
        /// <summary>
        /// Identifies the Filter dependency property
        /// </summary>
        public static readonly DependencyProperty FilterProperty =
            DependencyProperty.Register(nameof(Filter), typeof(IContentFilter), typeof(FilterWithPopupControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (sender, _) => ((FilterWithPopupControl)sender).Filter_Changed()));


        private void Filter_Changed()
        {
            if (Filter is not ContentFilter filter)
                return;

            Minimum = filter.Min;
            Maximum = filter.Max;
        }

    }

    public class ContentFilter : IContentFilter
    {
        public ContentFilter(double min, double max)
        {
            Min = min;
            Max = max;
        }

        public double Min { get; }

        public double Max { get; }

        public bool IsMatch(object? value)
        {
            if (value == null)
                return false;

            if (!double.TryParse(value.ToString(), out var number))
            {
                return false;
            }

            return (number >= Min) && (number <= Max);
        }
    }
}

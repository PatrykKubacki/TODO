using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TODO.Models {
	public class Validator : Behavior<Entry> {

		static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool),typeof(string), false);

		public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

		
		public bool IsValid {
			get { return (bool)base.GetValue(IsValidProperty); }
			private set { base.SetValue(IsValidPropertyKey, value); }
		}

		protected override void OnAttachedTo(Entry bindable) {
			bindable.TextChanged += HandleTextChanged;
		}

		void HandleTextChanged(object sender, TextChangedEventArgs e) {
			IsValid = !string.IsNullOrEmpty(((Entry)sender).Text);
		}

		protected override void OnDetachingFrom(Entry bindable) {
			bindable.TextChanged -= HandleTextChanged;
		}
	}
}

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TODO.Annotations;
using TODO.Entities;

namespace TODO.ViewModels {

	public class ToDosViewModel : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;

		private IList<TodoItem> _model;
		public IList<TodoItem> Model {
			get {
				return _model;
			}
			set {
				_model = value;
				OnPropertyChanged();
			}
		}

		public ToDosViewModel(IList<TodoItem> model) {
			_model = model;
		}

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

}

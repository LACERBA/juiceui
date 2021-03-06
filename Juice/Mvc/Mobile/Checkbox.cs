using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;

using Juice.Mobile;

namespace Juice.Mvc.Mobile {

	public partial class MobileHelpers {

		/// <summary>
		/// {summary}
		/// </summary>
		/// <param name="elementId">Sets the id attribute of the rendered element.</param>
		/// <param name="mini">Compact sized version</param>,
		/// <param name="theme">Defines the theme swatch letter (a-z)</param>
		/// <returns>CheckboxWidget</returns>
		public CheckboxWidget Checkbox(String elementId = "", Boolean mini = false, String theme = null) {
			var widget = new CheckboxWidget(_helper);

			widget.SetCoreOptions(elementId, null);
			widget.Options(mini, theme);

			return widget;
		}

	}

	public class CheckboxWidget : JuiceMobileWidget<CheckboxWidget>, IDisposable {

		public CheckboxWidget(HtmlHelper helper) : base(helper, null) {
			_optionsMap = new Dictionary<String, String> {
				{ "mini", "mini" },
				{ "theme", "theme" }
			};
		}

		public CheckboxWidget Options(Boolean mini = false, String theme = null) {
			base.SetOptions(
				JuiceHelpers.GetMemberInfo(() => mini),
				JuiceHelpers.GetMemberInfo(() => theme)
			);

			return this;
		}

		internal override System.Web.UI.HtmlTextWriterTag Tag {
			get {
				return System.Web.UI.HtmlTextWriterTag.Input;
			}
		}

		public override void RenderAttributes() {
			base.RenderAttributes();

			_writer.WriteAttribute("type", "checkbox");
		}

		public override void Render() {
			base.Render();

			if(_content != null) {
				base.RenderEnd();
			}
		}
	}
}

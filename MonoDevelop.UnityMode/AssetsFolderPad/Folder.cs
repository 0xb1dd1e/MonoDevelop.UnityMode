using System;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Core;
using Gdk;
using MonoDevelop.Ide.Gui;

namespace MonoDevelop.UnityMode
{
	public class Folder
	{
		public FilePath Path { get; set; }
		public UnitySolution UnitySolution { get; set; }
	}

	class FolderNodeBuilder: TypeNodeBuilder
	{
		public override Type NodeDataType {
			get { return typeof(Folder); }
		}

		public override Type CommandHandlerType {
			get { return typeof(FolderNodeCommandHandler); }
		}

		public override string GetNodeName (ITreeNavigator thisNode, object dataObject)
		{
			var file = (Folder) dataObject;
			return file.Path.FileName + "LUCAS";
		}

		public override void BuildNode (ITreeBuilder treeBuilder, object dataObject, ref string label, ref Pixbuf icon, ref Pixbuf closedIcon)
		{
			base.BuildNode (treeBuilder, dataObject, ref label, ref icon, ref closedIcon);

			var file = (Folder) dataObject;
			label = file.Path.FileName;
			icon = Context.GetIcon (Stock.ClosedFolder);
		}
	}

	class FolderNodeCommandHandler: NodeCommandHandler
	{
	}
}


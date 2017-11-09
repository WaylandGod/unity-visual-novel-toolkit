using System.Collections.Generic;
using Assets.Editor.Localization;
using Assets.Editor.System.ConnectionPoint;
using Assets.Editor.System.Node.CharacterNode.DialogueNode;
using Assets.Editor.ToolkitGui.Controls.ParametersPanel;
using UnityEngine;

namespace Assets.Editor.System.Node.CharacterNode.AnswerNode
{
	sealed class AnswerNodePresenter : NodePresenter
	{
		private readonly INodeView _nodeView;
		private readonly NodeParametersPanel _nodeParametersPanel;

		public AnswerNodePresenter(INodeView nodeView,
			NodeData nodeData,
			ConnectionPointPresenter connectionPointInPresenter,
			ConnectionPointPresenter connectionPointOutPresenter) :
			base(nodeView, nodeData, connectionPointInPresenter, connectionPointOutPresenter)
		{
			_nodeView = nodeView;

			var parameter = new NodeParameter("Texture Path")
			{
				IsClickable = true
			};

			_nodeParametersPanel = new NodeParametersPanel(new List<NodeParameter>
			{
				parameter
			});
		}

		public static NodePresenter Create(Vector2 position)
		{
			var nodeView = new AnswerNodeView(LocalizationStrings.AnswerNode, position);
			var connectionPointInPresenter = new ConnectionPointPresenter(new ConnectionPointView(ConnectionPointType.In));
			var connectionPointOutPresenter = new ConnectionPointPresenter(new ConnectionPointView(ConnectionPointType.Out));
			var nodeData = new AnswerNodeData();
			var nodePresenter = new AnswerNodePresenter(nodeView, nodeData, connectionPointInPresenter, connectionPointOutPresenter);
			return nodePresenter;
		}

		public override void Draw()
		{
			base.Draw();

			base.DrawParameters(_nodeParametersPanel);
		}
	}
}
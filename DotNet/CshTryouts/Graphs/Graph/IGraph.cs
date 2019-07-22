﻿using System.Collections.Generic;

namespace Graph
{
	public interface IGraph<TNode>
	{
		void AddNode(Node<TNode> node);
		void AddNode(TNode nodeValue);
		void AddEdge(Node<TNode> a, Node<TNode> b);

		bool Contains(TNode nodeValue);
		bool Contains(Node<TNode> node);
		bool Contains(Edge edge);

		Node<TNode> FindNode(TNode reference);
		Node<TNode> FindNode(Node<TNode> reference);
		Node<TNode> FindNode(int nodeId);
		Edge FindEdge(int aNodeId, int bNodeId);
		Edge FindEdge(int edgeId);

		bool Remove(TNode nodeValue);
		bool Remove(int nodeId);
		bool Remove(Node<TNode> node);
		bool Remove(Edge edge);

        // TODO:
        // IEnumerable<Node<T>> GetReferencesFor<T>(Node<T> node);
        // IEnumerable<Node<T>> GetReferencedNodesFor<T>(Node<T> node);

        IEnumerator<Node<TNode>> GetNodeSetEnumerator();
		IEnumerator<Edge> GetEdgeSetEnumerator();
	}
}

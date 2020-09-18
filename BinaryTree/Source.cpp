#include <iostream>
using namespace std;

struct TreeNode
{
	int data;
	TreeNode* left;
	TreeNode* right;
};

void Show(TreeNode*& node)
{
	if (node != NULL)
	{
		Show(node->left);
		cout << node->data << ' ';
		Show(node->right);
	}
}

void AddNode(int data, TreeNode *&Tree)
{
	if (NULL == Tree)
	{
		Tree = new TreeNode;
		Tree->data = data;
		Tree->left = Tree->right = NULL;
	}

	if (data < Tree->data)
	{
		if (Tree->left != NULL)
			AddNode(data, Tree->left);
		else
		{
			Tree->left = new TreeNode;
			Tree->left->left = Tree->left->right = NULL;
			Tree->left->data = data;
		}
	}

	if (data > Tree->data)
	{
		if (Tree->right != NULL)
			AddNode(data, Tree->right);
		else
		{
			Tree->right = new TreeNode;
			Tree->right->left = Tree->right->right = NULL;
			Tree->right->data = data;
		}
	}
}

int main()
{
	TreeNode* Tree = NULL;
	
	for (int i = 0; i < 20; i++)
		AddNode(i, Tree);

	Show(Tree);

	return 0;
}
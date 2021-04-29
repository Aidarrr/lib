import java.util.Scanner;

class Node {
    int val;
    Node next;

    public Node(int val) {
        this.val = val;
        next = null;
    }
}

class ForwardList {
    Node start;
    int size;

    public ForwardList() {
        start = null;
        size = 0;
    }

    public Node getByPos(int pos) {
        Node elem = start;
        for (int i = 0; i < pos; i++) {
            elem = elem.next;
        }
        return elem;
    }

    public void push(int val) {
        Node elem = new Node(val);
        if (size > 0) {
            elem.next = start;
        }
        start = elem;
        size++;
    }

    public void insertAfter(int pos, int val) {
        if (pos == -1) {
            push(val);
            return;
        }

        Node nodeForInsertion = new Node(val);
        Node prevNode = getByPos(pos);
        nodeForInsertion.next = prevNode.next;
        prevNode.next = nodeForInsertion;
        size++;
    }

    public void pop() {
        if (size == 0)
            return;

        start = start.next;
        size--;
    }

    public void eraseAfter(int pos) {
        if (pos == -1) {
            pop();
            return;
        }

        Node elem = getByPos(pos);
        if (elem.next == null)
            return;

        elem.next = elem.next.next;
        size--;
    }
}

class S {
    public static void main(String[] args) {
        ForwardList forwardList = new ForwardList();
        Scanner scanner = new Scanner(System.in);
        int m;
        m = scanner.nextInt();

        for (int i = 0; i < m; i++) {
            int query = scanner.nextInt();
            if (query == 1) {
                int pos = scanner.nextInt();
                int val = scanner.nextInt();
                forwardList.insertAfter(pos, val);

            } else if (query == 2) {
                int pos = scanner.nextInt();
                forwardList.eraseAfter(pos);
            }else{
                int pos = scanner.nextInt();
                System.out.println(forwardList.getByPos(pos).val);
            }
        }

    }
}

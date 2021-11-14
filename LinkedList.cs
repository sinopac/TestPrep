namespace MyTestPrep
{
    public class ListNode
    {
        public int val;

        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public static class LinkedListTest
    {
        /// https://leetcode.com/problems/add-two-numbers/
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var sum = new ListNode();
            var lastNode = sum;

            while (l1 != null || l2 != null)
            {
                var val1 = l1 == null ? 0 : l1.val;
                var val2 = l2 == null ? 0 : l2.val;
                var val = val1 + val2 + lastNode.val;

                lastNode.val = val % 10;
                var carry = val > 9 ? 1 : 0;

                if (l1?.next != null || l2?.next != null || val > 9)
                    lastNode.next = new ListNode(carry);

                l1 = l1?.next;
                l2 = l2?.next;
                lastNode = lastNode.next;
            }

            return sum;
        }

        /// <summary>
        /// https://leetcode.com/problems/rotate-list/
        /// </summary>
        public static ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null)
                return head;

            // close the linked list into the ring
            var old_tail = head;
            int n;

            for (n = 1; old_tail.next != null; n++)
                old_tail = old_tail.next;

            old_tail.next = head;

            // find new tail : (n - k % n - 1)th node
            // and new head : (n - k % n)th node
            var new_tail = head;
            for (int i = 0; i < n - k % n - 1; i++)
                new_tail = new_tail.next;

            var new_head = new_tail.next;

            // break the ring
            new_tail.next = null;

            return new_head;
        }
    }
}
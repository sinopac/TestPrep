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
    }
}
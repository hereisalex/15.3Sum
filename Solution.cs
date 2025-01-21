public class Solution
{
    public static void Main(string[] args)
    {
        var solution = new Solution();
        var result = solution.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
        Console.WriteLine(result);
    }

    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        IList<IList<int>> result = new List<IList<int>>();
        var n = nums.Length;
        for (int i = 0; i < n - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) //skip duplicates
            {
                continue;
            }
            var l = i + 1; // 0 1 2 3 4 5
            var r = n - 1; //|i|l|_|_|_|r|
                           // ^ ^       ^
            while (l < r)
            {
                var sum = nums[i] + nums[l] + nums[r];

                if (sum == 0)
                {
                    result.Add(new List<int> { nums[i], nums[l], nums[r] });
                    while (l < r && nums[l] == nums[l + 1]) { l++; } //move left pointer to the right, to the next non-identical digit
                    while (l < r && nums[r] == nums[r - 1]) { r--; } //move right pointer to the left, the the next non-identical digit
                    l++;
                    r--;
                }
                else if (sum < 0)
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }
        }
        return result;
    }
}

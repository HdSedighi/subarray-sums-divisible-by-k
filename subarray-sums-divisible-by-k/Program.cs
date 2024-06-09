using System;
using System.Collections.Generic;

public class Solution {
    public int SubarraysDivByK(int[] nums, int k) {
        // Dictionary to store the count of prefix sums modulo k
        Dictionary<int, int> prefixSumCounts = new Dictionary<int, int>();
        // Initialize the prefix sum count for remainder 0 as 1
        prefixSumCounts[0] = 1;
        
        int prefixSum = 0;
        int result = 0;
        
        foreach (int num in nums) {
            // Update the prefix sum
            prefixSum += num;
            // Calculate the current remainder of the prefix sum with k
            int remainder = ((prefixSum % k) + k) % k;
            
            // Check if this remainder has been seen before
            if (prefixSumCounts.ContainsKey(remainder)) {
                // If it has, it means there are prefix sums that when subtracted give a sum divisible by k
                result += prefixSumCounts[remainder];
                // Increment the count for this remainder
                prefixSumCounts[remainder]++;
            } else {
                // If not, initialize the count for this remainder
                prefixSumCounts[remainder] = 1;
            }
        }
        
        return result;
    }
}

// Example usage
public class Program {
    public static void Main() {
        Solution solution = new Solution();
        int[] nums1 = {4, 5, 0, -2, -3, 1};
        int k1 = 5;
        Console.WriteLine(solution.SubarraysDivByK(nums1, k1)); // Output: 7

        int[] nums2 = {5};
        int k2 = 9;
        Console.WriteLine(solution.SubarraysDivByK(nums2, k2)); // Output: 0
    }
}

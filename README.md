# Intuition
<!-- Describe your first thoughts on how to solve this problem. -->
To find the number of non-empty subarrays that have a sum divisible by `k`, we can utilize the properties of prefix sums and remainders. By keeping track of the prefix sums modulo `k`, we can determine if a subarray sum is divisible by `k` by checking if the difference between two prefix sums is divisible by `k`.

# Approach
<!-- Describe your approach to solving the problem. -->
1. **Prefix Sum Calculation**: Compute a running sum (`prefixSum`) as we iterate through the array.
2. **Remainder Calculation**: For each `prefixSum`, compute its remainder when divided by `k`. Use `(prefixSum % k + k) % k` to handle negative values correctly.
3. **Hash Map Usage**: Use a hash map (`prefixSumCounts`) to store the count of each remainder. Initialize the count for remainder 0 to 1 because a prefix sum that is exactly divisible by `k` should be considered.
4. **Count Subarrays**: For each remainder, if it has been seen before in the hash map, it means there are subarrays ending at the current index whose sums are divisible by `k`. Add the count of this remainder from the hash map to the result.
5. **Update Hash Map**: Increment the count of the current remainder in the hash map.

# Complexity
- Time complexity:
<!-- Add your time complexity here, e.g. $$O(n)$$ -->
The time complexity is $$O(n)$$, where `n` is the length of the input array. This is because we pass through the array once, performing constant-time operations for each element.

- Space complexity:
<!-- Add your space complexity here, e.g. $$O(n)$$ -->
The space complexity is $$O(k)$$, where `k` is the modulus value. This is because, in the worst case, we need to store up to `k` different remainders in the hash map.


# Code
```
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
```

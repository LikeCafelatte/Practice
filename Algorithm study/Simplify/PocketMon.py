import collections
def solution(nums):
    return min(len(nums) // 2, len(collections.Counter(nums).keys()))
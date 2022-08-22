from heapq import heappush, heappop
def solution(scoville, K):
    answer = 0
    scoville.sort()
    while scoville[0] < K:
        answer += 1
        heappush(scoville, heappop(scoville) + 2 * heappop(scoville))
        if len(scoville) < 2 and min(scoville) < K :
            return -1
    return answer
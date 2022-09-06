def solution(n, s, a, b, fares):
    # hash 사용을 위해 fares를 각 노드의 번호를 key로 하는 dictionary로 변환
    fares_dict = {p:[] for p in range(1, n + 1)}
    for fare in fares:
        fares_dict[fare[0]].append([fare[1], fare[2]])
        fares_dict[fare[1]].append([fare[0], fare[2]])
    #dijkstra알고리즘 활용, 출발 노드로부터 최단경로 탐색
    distances_s = dijkstra(n, s, fares_dict); distances_a = dijkstra(n, a, fares_dict); distances_b = dijkstra(n, b, fares_dict);
    return min([distances_s[i] + distances_a[i] + distances_b[i] for i in range(1, n + 1)])

def dijkstra(n, s, fares_dict):
    INF = 2000000000
    distances = [INF] * (n + 1)
    q = [[s, 0]]
    while len(q) > 0:
        dq = q.pop()
        distances[dq[0]] = min(distances[dq[0]], dq[1])
        for fare in fares_dict[dq[0]]:
            if distances[fare[0]] > distances[dq[0]] + fare[1]:
                q.append([fare[0], distances[dq[0]] + fare[1]])
    return distances

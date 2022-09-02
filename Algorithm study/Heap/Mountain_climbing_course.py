from heapq import heappush, heappop
def solution(n, paths, gates, summits):
    answer = [50001, 10000001]
    intensities = {summit: [10000001 for _ in range(n + 1)] for summit in summits}
    paths_dict = {}
    for path in paths:
        if path[0] in paths_dict:
            paths_dict[path[0]].append([path[1], path[2]])
        else:
            paths_dict[path[0]] = [[path[1], path[2]]]
        if path[1] in paths_dict:
            paths_dict[path[1]].append([path[0], path[2]])
        else:
            paths_dict[path[1]] = [[path[0], path[2]]]
    
    result = 10000001
    for summit in summits:
        heap = []
        current = summit
        for next_path in paths_dict[current]:
            heappush(heap, (next_path[1], current, next_path, next_path[1]))
        while len(heap) > 0:
            dq = heappop(heap)
            parent = dq[1]
            current = dq[2][0]
            intensity = dq[3]
            intensities[summit][current] = min(intensities[summit][current], intensity)
            if current in summits or intensity >= result:
                continue
            if current in gates:
                result = min(result, intensity)
                continue
            for next_path in paths_dict[current]:
                if next_path[0] != parent and intensities[summit][next_path[0]] > next_path[1]:
                    heappush(heap, (next_path[1], current, next_path, max(intensity, next_path[1])))
        
        if answer[1] > result:
            answer = [summit, result]
    
    return answer

from heapq import heappush, heappop
def solution(n, paths, gates, summits):
    answer = [50001, 10000001]
    distances = {summit: [10000001 for _ in range(n + 1)] for summit in summits}
    paths_dict = {}
    for path in paths:
        if path[0] in paths_dict:
            paths_dict[path[0]].append([path[1], path[2]])
        else:
            paths_dict[path[0]] = [[path[1], path[2]]]
        if path[1] in paths_dict:
            paths_dict[path[1]].append([path[0], path[2]])
        else:
            paths_dict[path[1]] = [[path[0], path[2]]]
    
    result = 10000001
    for summit in summits:
        heap = []
        current = summit
        for next_path in paths_dict[current]:
            heappush(heap, (next_path[1], current, next_path, next_path[1]))
        while len(heap) > 0:
            dq = heappop(heap)
            parent = dq[1]
            current = dq[2][0]
            intensity = dq[3]
            distances[summit][current] = min(distances[summit][current], dq[0])
            if current in summits or intensity >= result:
                continue
            if current in gates:
                result = min(result, intensity)
                continue
            for next_path in paths_dict[current]:
                if next_path[0] != parent and distances[summit][next_path[0]] > next_path[1]:
                    heappush(heap, (next_path[1], current, next_path, max(intensity, next_path[1])))
        
        if answer[1] > result:
            answer = [summit, result]
    
    return answer


from heapq import heappush, heappop
def solution(n, paths, gates, summits):
    answer = [50001, 10000001]
    intensities = [10000001 for _ in range(n + 1)]
    paths_dict = {}
    for path in paths:
        if path[0] in paths_dict:
            paths_dict[path[0]].append([path[1], path[2]])
        else:
            paths_dict[path[0]] = [[path[1], path[2]]]
        if path[1] in paths_dict:
            paths_dict[path[1]].append([path[0], path[2]])
        else:
            paths_dict[path[1]] = [[path[0], path[2]]]
    
    result = 10000001
    for gate in gates:
        heap = []
        current = gate
        for next_path in paths_dict[current]:
            heappush(heap, (next_path[1], current, next_path, next_path[1]))
        while len(heap) > 0:
            dq = heappop(heap)
            parent = dq[1]
            current = dq[2][0]
            intensity = dq[3]
            intensities[current] = min(intensities[current], intensity)
            if current in gates or current in summits or intensity >= result:
                continue
            for next_path in paths_dict[current]:
                if next_path[0] != parent and intensities[next_path[0]] > next_path[1]:
                    heappush(heap, (next_path[1], current, next_path, max(intensity, next_path[1])))
    for summit in summits:
        if answer[1] > result:
            answer = [summit, result]
    
    return answer

from heapq import heappush, heappop
def solution(n, paths, gates, summits):
    answer = [50001, 10000001]
    intensities = [10000001 for _ in range(n + 1)]
    paths_dict = {}
    for path in paths:
        if path[0] in paths_dict:
            paths_dict[path[0]].append([path[1], path[2]])
        else:
            paths_dict[path[0]] = [[path[1], path[2]]]
        if path[1] in paths_dict:
            paths_dict[path[1]].append([path[0], path[2]])
        else:
            paths_dict[path[1]] = [[path[0], path[2]]]
    
    result = 10000001
    heap = []
    for gate in gates:
        current = gate
        for next_path in paths_dict[current]:
            heappush(heap, (next_path[1], current, next_path, next_path[1]))
    while len(heap) > 0:
        dq = heappop(heap)
        parent = dq[1]
        current = dq[2][0]
        intensity = dq[3]
        intensities[current] = min(intensities[current], intensity)
        if current in gates or intensity > result:
            continue
        if current in summits:
            result = intensities[current]
            continue
        for next_path in paths_dict[current]:
            if next_path[0] != parent and intensities[next_path[0]] > max(intensity, next_path[1]):
                heappush(heap, (next_path[1], current, next_path, max(intensity, next_path[1])))
    for summit in summits:
        if answer[1] > intensities[summit]:
            answer = [summit, intensities[summit]]
            
    return answer
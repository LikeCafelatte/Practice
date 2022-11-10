# 등대
# https://school.programmers.co.kr/learn/courses/30/lessons/133500

def solution(n, lighthouse):
    answer = n
    link = [[] for i in range(n + 1)]
    for a, b in lighthouse:
        link[a].append(b)
        link[b].append(a)
    for i in range(1, n + 1):
        states = [0 for _ in range(n + 1)]
        total = 0
        stack = [i]
        while stack:
            poped = stack.pop()
            if states[poped] == 0:
                states[poped] = 1
                for leaf in link[poped]:
                    states[leaf] = 1
                    stack.extend(link[leaf])
                total += 1
        answer = min(answer, total)
    return answer



import sys
sys.setrecursionlimit(10**7)
def solution(n, lighthouse):
    link = [[] for i in range(n + 1)]
    for a, b in lighthouse:
        link[a].append(b)
        link[b].append(a)
    for idx, leafs in enumerate(link):
        print(idx, leafs)
    headnode = Node(1, 1)
    headnode.add_node(link)
    return headnode.turn_on()

class Node:
    def __init__(self, id, parent):
        self.leafnodes = []
        self.id = id
        self.parent = parent
        self.light = False
        self.state = False
    
    def add_node(self, link):
        for leafnode in link[self.id]:
            if leafnode != self.parent:
                self.leafnodes.append(Node(leafnode, self.id))
                self.leafnodes[-1].add_node(link)
                
    def turn_on(self):
        answer = 0
        if self.leafnodes:
            for leaf in self.leafnodes:
                if leaf.leafnodes:
                    answer += leaf.turn_on()
                else:
                    if leaf.light:
                        self.state = True
                    if not leaf.state:
                        if not self.light:
                            self.light = True
                            answer += 1
                        leaf.state = True
        return answer




import sys
sys.setrecursionlimit(10**7)
def solution(n, lighthouse):
    link = [[] for i in range(n + 1)]
    for a, b in lighthouse:
        link[a].append(b)
        link[b].append(a)
    headnode = Node(1)
    headnode.add_node(link)
    answer, temp = 0, -1
    while temp != answer:
        temp = answer
        answer += headnode.turn_on()
        print(temp, answer)
    return answer
class head:
    def __init__(self):
        self.state = True
class Node:
    def __init__(self, id, parent = head()):
        self.leafnodes = []
        self.id = id
        self.parent = parent
        self.light = False
        self.state = False
    
    def add_node(self, link):
        for leafnode in link[self.id]:
            if leafnode != self.parent:
                self.leafnodes.append(Node(leafnode, self))
                self.leafnodes[-1].add_node(link)
                
    def turn_on(self):
        answer = 0
        print(f'{self.id} node\'s state is {self.state}')
        if self.leafnodes:
            for leaf in self.leafnodes:
                if leaf.leafnodes:
                    answer += leaf.turn_on()
                else:
                    print(f'{leaf.id} node\'s state is {leaf.state}')
                    if leaf.light:
                        self.state = True
                    if not leaf.state:
                        if not self.light:
                            self.light = True
                            self.state = True
                            self.parent.state = True
                            print(self.id, True)
                            answer += 1
                        leaf.state = True
        return answer


import sys
sys.setrecursionlimit(10**7)
def solution(n, lighthouse):
    link = [[] for i in range(n + 1)]
    for a, b in lighthouse:
        link[a].append(b)
        link[b].append(a)
    headnode = Node(1)
    headnode.add_node(link)
    answer, temp = 0, -1
    while temp != answer:
        temp = answer
        answer += headnode.turn_on()
    return answer
class head:
    def __init__(self):
        self.state = False
        self.id = 1
class Node:
    def __init__(self, id, parent = head()):
        self.leafnodes = []
        self.id = id
        self.parent = parent
        self.light = False
        self.state = False
    
    def add_node(self, link):
        for leafnode in link[self.id]:
            if leafnode != self.parent.id:
                self.leafnodes.append(Node(leafnode, self))
                self.leafnodes[-1].add_node(link)
                
    def turn_on(self):
        answer = 0
        if not self.leafnodes:
            return answer
        for leaf in self.leafnodes:
            if leaf.leafnodes:
                answer += leaf.turn_on()
            else:
                if leaf.light:
                    self.state = True
                if not leaf.state and not self.light:
                    self.light = True
                    self.state = True
                    self.parent.state = True
                    for l in self.leafnodes:
                        l.state = True
                    answer += 1
        if self.state_check() or (answer == 0 and not self.state):
            self.light = True
            self.state = True
            self.parent.state = True
            for l in self.leafnodes:
                l.state = True
            answer += 1
            
        return answer
    def state_check(self):
        if self.state:
            return False
        if self.parent.state:
            return False
        for leaf in self.leafnodes:
            if leaf.state:
                return False
        return True



import sys
sys.setrecursionlimit(10**7)
def solution(n, lighthouse):
    link = [[] for i in range(n + 1)]
    for a, b in lighthouse:
        link[a].append(b)
        link[b].append(a)
    headnode = Node(1)
    headnode.add_node(link)
    answer, temp = 0, -1
    while temp != answer:
        temp = answer
        answer += headnode.turn_on()
        print(temp, answer)
    return answer
class head:
    def __init__(self):
        self.state = False
        self.id = 1
class Node:
    def __init__(self, id, parent = head()):
        self.leafnodes = []
        self.id = id
        self.parent = parent
        self.light = False
        self.state = False
    
    def add_node(self, link):
        for leafnode in link[self.id]:
            if leafnode != self.parent.id:
                self.leafnodes.append(Node(leafnode, self))
                self.leafnodes[-1].add_node(link)
                
    def turn_on(self):
        answer = 0
        print(f'{self.id} node\'s state is {self.state}. (node)')
        if not self.leafnodes:
            return answer
        for leaf in self.leafnodes:
            if leaf.leafnodes:
                answer += leaf.turn_on()
            else:
                print(f'{leaf.id} node\'s state is {leaf.state}. (leaf)')
                if leaf.light:
                    self.state = True
                if not leaf.state and not self.light:
                    self.light = True
                    self.state = True
                    self.parent.state = True
                    for l in self.leafnodes:
                        l.state = True
                    print(self.id, True)
                    answer += 1
        if answer == 0 and not self.state:
            self.light = True
            self.state = True
            self.parent.state = True
            for l in self.leafnodes:
                l.state = True
            print(self.id, True)
            answer += 1
            
        return answer
    def state_check(self):
        if self.state:
            return False
        if self.parent.state:
            return False
        for leaf in self.leafnodes:
            if leaf.state:
                return False
        return True





import sys
sys.setrecursionlimit(10**7)
def solution(n, lighthouse):
    link = [[] for i in range(n + 1)]
    for a, b in lighthouse:
        link[a].append(b)
        link[b].append(a)
    headnode = Node(1)
    headnode.add_node(link)
    answer, temp = 0, -1
    while temp != answer:
        temp = answer
        answer += headnode.turn_on()
        print(temp, answer)
    return answer
class head:
    def __init__(self):
        self.state = False
        self.id = 1
class Node:
    def __init__(self, id, parent = head()):
        self.leafnodes = []
        self.id = id
        self.parent = parent
        self.light = False
        self.state = False
        self.completed = False
    
    def add_node(self, link):
        for leafnode in link[self.id]:
            if leafnode != self.parent.id:
                self.leafnodes.append(Node(leafnode, self))
                self.leafnodes[-1].add_node(link)
                
    def turn_on(self):
        answer = 0
        print(f'{self.id} node\'s state is {self.state}. (node), completed state is {self.completed}')
        if not self.leafnodes or self.completed:
            return answer
        for leaf in self.leafnodes:
            if leaf.leafnodes:
                answer += leaf.turn_on()
            else:
                print(f'{leaf.id} node\'s state is {leaf.state}. (leaf), completed state is {leaf.completed}')
                if leaf.light:
                    self.state = True
                if not leaf.state:
                    if not self.light:
                        self.light = True
                        self.state = True
                        self.parent.state = True
                        for l in self.leafnodes:
                            l.state = True
                            if not l.leafnodes:
                                l.completed = True
                        print(self.id, True)
                        answer += 1
        if answer == 0 and not self.state:
            self.light = True
            self.state = True
            self.parent.state = True
            for l in self.leafnodes:
                l.state = True
            print(self.id, True)
            answer += 1
        for leaf in self.leafnodes:
            if not leaf.completed:
                break
        else:
            if self.state:
                self.completed = True
            
        return answer








import sys
sys.setrecursionlimit(10**7)
def solution(n, lighthouse):
    link = [[] for i in range(n + 1)]
    for a, b in lighthouse:
        link[a].append(b)
        link[b].append(a)
    headnode = Node(1)
    headnode.add_node(link)
    answer, temp = 0, -1
    while temp != answer:
        temp = answer
        answer += headnode.turn_on()
        print(temp, answer)
    return answer
class head:
    def __init__(self):
        self.state = False
        self.id = 1
        self.leafnodes = []
class Node:
    def __init__(self, id, parent = head()):
        self.leafnodes = []
        self.id = id
        self.parent = parent
        self.light = False
        self.state = False
        self.completed = False
    
    def add_node(self, link):
        for leafnode in link[self.id]:
            if leafnode != self.parent.id:
                self.leafnodes.append(Node(leafnode, self))
                self.leafnodes[-1].add_node(link)
                
    def turn_on(self):
        answer = 0
        print(f'{self.id} node\'s state is {self.state}. (node), completed state is {self.completed}')
        if not self.leafnodes:
            return answer
        for leaf in self.leafnodes:
            if leaf.leafnodes:
                answer += leaf.turn_on()
            else:
                print(f'{leaf.id} node\'s state is {leaf.state}. (leaf), completed state is {leaf.completed}')
                if leaf.light:
                    self.state = True
                if not leaf.state:
                    if not self.light:
                        self.light = True
                        self.state = True
                        self.parent.state = True
                        for l in self.leafnodes:
                            l.state = True
                            if not l.leafnodes:
                                l.completed = True
                        for l in self.parent.leafnodes:
                            if not l.completed:
                                break
                        else:
                            self.parent.completed = True
                        print(self.id, True)
                        answer += 1
        if answer == 0 and not self.state:
            self.light = True
            self.state = True
            self.parent.state = True
            for l in self.leafnodes:
                l.state = True
            print(self.id, True)
            answer += 1
        for leaf in self.leafnodes:
            if not leaf.completed:
                break
        else:
            if self.state:
                self.completed = True
                if type(self.parent) != head:
                    self.parent.leafnodes.remove(self)
                self.leafnodes = []
            
        return answer

##################################################
import sys
sys.setrecursionlimit(10**7)
def solution(n, lighthouse):
    link = [[] for i in range(n + 1)]
    for a, b in lighthouse:
        link[a].append(b)
        link[b].append(a)
    headnode = Node(1)
    headnode.add_node(link)
    answer, temp = 0, -1
    while temp != answer:
        temp = answer
        answer += headnode.turn_on()
        print(temp, answer)
    return answer

class Node:
    def __init__(self, id, parent = None):
        self.leafnodes = []
        self.id = id
        self.parent = parent
        self.light = False
        self.state = False
        self.completed = False
    
    def add_node(self, link):
        for leafnode in link[self.id]:
            if self.parent == None or leafnode != self.parent.id:
                self.leafnodes.append(Node(leafnode, self))
                self.leafnodes[-1].add_node(link)
                
    def turn_on(self):
        answer = 0
        print(f'{self.id} node\'s state is {self.state}. (node), completed state is {self.completed}')
        if not self.leafnodes:
            return answer
        for leaf in self.leafnodes:
            if leaf.leafnodes:
                answer += leaf.turn_on()
            else:
                print(f'{leaf.id} node\'s state is {leaf.state}. (leaf), completed state is {leaf.completed}')
                if leaf.light:
                    self.state = True
                if not leaf.state:
                    if not self.light:
                        self.light = True
                        self.state = True
                        if self.parent != None:
                            self.parent.state = True
                        for l in self.leafnodes:
                            l.state = True
                            if not l.leafnodes:
                                l.completed = True
                        answer += 1
        for leaf in self.leafnodes:
            if not leaf.completed:
                break
        else:
            if self.state:
                self.completed = True
                if self.parent != None:
                    self.parent.leafnodes.remove(self)
            
        return answer
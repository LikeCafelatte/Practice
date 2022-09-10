def solution(skill, skill_trees):
    trees = ["".join([s for s in t if s in skill]) for t in skill_trees]
    skills = [skill[:i] for i in range(len(skill) + 1)]
    return len([t for t in trees if t in skills])

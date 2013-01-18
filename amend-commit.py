#!/usr/bin/env python

if __name__ == '__main__':
    pass

import os
import sys
import subprocess

GIT_ADD = """git add ."""
GIT_COMMIT = """git commit -a -Fcommit.txt --amend"""

def runCommand(command):
    process = subprocess.Popen(command, shell=True, stdout=subprocess.PIPE)
    out = process.stdout.read().strip()
    print(out)

def commit_git():
    runCommand(GIT_ADD)
    runCommand(GIT_COMMIT)
    

commit_git()

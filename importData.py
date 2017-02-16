#/usr/bin/env python

import math

class gImportData():
    """
    A program to import data
    usage:
        >>> importData = gImportData();
        >>> processingRow = importData.getIthRowOfFile(0, '../data/brushteeth');
    """
    def __init__(self):
        pass

    def getIthRowOfFile(self, i, _dir):
        _file = open(_dir, 'r');
        rowRet = [];

        for each_line in _file:
            x = each_line.split();
            value = float(x[0]);
            if value < math.pi*2:
                rowRet.append(x[0]);
        return rowRet;

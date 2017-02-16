#/usr/bin/env python

"this is a module for data normalization"

from processingData import ProcessingData
from sklearn import preprocessing

class DataNormalization():
    """
    A program to normalize data
    usage:
        >>> normalizedData = DataNormalization();
    """
    def __init__(self):
        self.processingData = ProcessingData();
        self.normalizedData = self.normalize(self.processingData.processedData);
        self.standardizedData = self.standardize(self.processingData.processedData);

    def normalize(self, _data):
        normalizedData = preprocessing.normalize(_data);
        return normalizedData;

    def standardize(self, _data):
        standardizedData = preprocessing.scale(_data);
        i = 0;
        dataRet = [];
        while i < len(standardizedData):
            if standardizedData[i] < 10:
                dataRet.append(standardizedData[i]);
            i = i + 1;
        #return dataRet;
        return standardizedData;



if __name__ == '__main__':
    normalizedData = DataNormalization();

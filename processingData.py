#/usr/bin/env python

"this is a module for processing data"

from importData import gImportData
from sklearn import preprocessing
import math

class ProcessingData():
    """A program to process data
    usage:
        >>> processingData = ProcessingData();
        >>> processedData = processingData.processedData;
    """
    def __init__(self):
        self.importData = gImportData();
        self.processingRow = self.importData.getIthRowOfFile(0, '../data/guiyuequzaohou');
        #self.processedData = self.dataProcessingFromQingHua();
        #self.processedData = self.dataProcessingFromMe();
        #self.processedData = self.dataProcessingFromMeBySubWithPreValue();
        self.processedData = self.dataProcessingFromMeSub2Pi();
        self.normalizedData = self.preprocessingNormalize();
        print("Normalized : ", type(self.normalizedData));
        self.standardizedData = self.preprocessingStandardize();
        print("standard: ", type(self.standardizedData));

    def dataProcessingFromQingHua(self):
        rowLength = len(self.processingRow);
        dataRet = [];
        accumulatedValue = float(0.0);
        i = 0;
        dataPre = 0;
        if rowLength > 0:
            dataPre = self.processingRow[0];
            i = i + 1;
            dataRet.append(self.processingRow[0]);

        while i < rowLength :
            subResult = float(self.processingRow[i]) + float(accumulatedValue) - float(dataPre);
            dataPre = float(self.processingRow[i]) + float(accumulatedValue);
            dataRet.append(float(self.processingRow[i]) + accumulatedValue);
            if subResult > math.pi:
                accumulatedValue = accumulatedValue + float(2 * math.pi);
            elif subResult < -(math.pi):
                accumulatedValue = accumulatedValue - float(2 * math.pi);
            else:
                accumulatedValue = float(accumulatedValue);

            i = i + 1;
        return dataRet;

    def dataProcessingFromMe(self):
        rowLength = len(self.processingRow);
        dataRet = [];
        i = 0;
        while i < rowLength:
            dataRet.append(float(self.processingRow[i]));
            i = i + 1;
        return dataRet;

    def dataProcessingFromMeBySubWithPreValue(self):
        rowLength = len(self.processingRow);
        dataRet = [];
        accumulatedValue = float(0.0);
        i = 0;
        dataPre = 0;
        if rowLength > 0:
            dataPre = self.processingRow[0];
            i = i + 1;
            dataRet.append(float(self.processingRow[0]));

        while i < rowLength :
            subResult = float(self.processingRow[i]) - float(dataPre);
            dataPre = float(self.processingRow[i]);
            dataRet.append(float(self.processingRow[i]) + float(accumulatedValue));
            if subResult > math.pi:
                accumulatedValue = accumulatedValue + float(2 * math.pi);
            elif subResult < -math.pi:
                accumulatedValue = accumulatedValue - float(2 * math.pi);
            else:
                accumulatedValue = accumulatedValue;

            i = i + 1;
        return dataRet;

    def dataProcessingFromMeSub2Pi(self):
        rowLength = len(self.processingRow);
        dataRet = [];
        i = 0;
        while i < rowLength:
            temp = float(self.processingRow[i]);
            if temp > math.pi:
                temp = -(2*math.pi - temp);
            if temp < 2.2:
                dataRet.append(temp);
            i = i+1;


        return dataRet;

    def preprocessingNormalize(self):
        normalizedData = preprocessing.normalize(self.processedData);
        return normalizedData;

    def preprocessingStandardize(self):
        standardizedData = preprocessing.scale(self.processedData);
        return standardizedData;

    def temporaryData(self):
        X = np.linspace(0)

#if __name__ == '__main__':
#    processingData = ProcessingData();


#/usr/bin/env python

from processingData import ProcessingData
import numpy as np
import matplotlib.pyplot as plt
from sklearn.tree import DecisionTreeRegressor
from sklearn.ensemble import AdaBoostRegressor

class PlotData():
    """
    A program to plot
    usage:
        >>>
    """
    def __init__(self):
        self.processingData = ProcessingData();
        self.dataSetCreateAndPlot(self.processingData.processedData, 'list');
        #self.dataSetCreateAndPlot(self.processingData.normalizedData, 'numpyndarray');
        self.dataSetCreateAndPlot(self.processingData.standardizedData);

    def dataSetCreateAndPlot(self, _data, _flag = ' '):
        if _flag == 'numpyndarray':
            #self.plotFigureWithNdarray(_data);
            print _data;
        else:
            (X, Y, rng) = self.dataSetCreate(_data, _flag);
            (y_1, y_2) = self.fitRegressionModel(X, Y, rng);
            self.plotFigure(X, Y, y_1, y_2);


    def dataSetCreate(self, _data, _flag):
        dataLength = len(_data);
        rng = np.random.RandomState(1);
        X = np.linspace(0, 6, dataLength)[:, np.newaxis];
        print '-------x--------'
        print X
        print type(X)
        Y = [];
        if _flag == 'list':
            i = 0;
            while i < len(_data):
                Y.append(float(_data[i]));
                i = i + 1;
            Y = np.array(Y);
            print("Y: ", type(Y));
        else:
            print _data;
            Y = _data;
        return (X, Y, rng);

    def fitRegressionModel(self, X, Y, rng):
        regr_1 = DecisionTreeRegressor(max_depth=4);
        regr_2 = AdaBoostRegressor(DecisionTreeRegressor(max_depth=4), \
                                   n_estimators=300, random_state=rng);
        regr_1.fit(X, Y);
        regr_2.fit(X, Y);
        #predict
        y_1 = regr_1.predict(X);
        y_2 = regr_2.predict(X);
        return (y_1, y_2);


    def plotFigure(self, X, Y, y_1, y_2):
        plt.figure();
        plt.scatter(X, Y, c="k", label="training sameples");
        plt.plot(X, y_1, c="g", label="n_estimators=1", linewidth=2);
        plt.plot(X, y_2, c="r", label="n_estimators=300", linewidth=2);
        plt.xlabel("data");
        plt.ylabel("target");
        plt.title("Boost Decision Tree Regression");
        plt.legend();
        plt.show();

    def plotFigureWithNdarray(self, _data):
        plt.figure();
        plt.plot(_data, c="k", linewidth=2);
        plt.title("preprocessing");
        plt.legend();
        plt.show();


if __name__ == '__main__':
    plotData = PlotData();

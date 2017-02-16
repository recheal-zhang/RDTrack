#/usr/bin/env python

import numpy as np
import matplotlib.pyplot as plt
from sklearn.ensemble import GradientBoostingRegressor
from sklearn.tree import DecisionTreeRegressor
from sklearn.ensemble import AdaBoostRegressor
from dataNormalization import DataNormalization


class PredictionIntervalsForGradientBoostingRegression():
    """
    A program to show how quantile regression can be used to create prediction intervals
    usage:
        >>>
    """
    def __init__(self):
        limitation = 10;
        alpha = 0.95;
        self.normalizedData = DataNormalization();

        print self.normalizedData.normalizedData;
        print type(self.normalizedData.normalizedData);
        ndarrayToListData = self.normalizedData.normalizedData.tolist();
        print ndarrayToListData;
        print type(ndarrayToListData);
        print self.normalizedData.standardizedData;
        print type(self.normalizedData.standardizedData);

        self.data = self.normalizedData.standardizedData;
        #self.data = ndarrayToListData[0];
        self.dataLength = len(self.data);
        self.X = self.generateXValue(limitation, self.dataLength);
        self.Y = self.generateYValue(self.data);
        self.xx = self.generatexxValue(alpha, limitation, self.dataLength);
        (y_upper, y_lower, y_pred) = self.regression(self.X, self.Y, self.xx, alpha);
        (y_1, y_2) = self.decisionTreeRegression(self.X, self.Y);
        self.plotfigure(self.X, self.Y, self.xx, y_upper, y_lower, y_pred, y_1, y_2);

    def predict(self, _x):
        """the function to predict"""
        return _x * np.sin(_x);

    def generateXValue(self, limitation, _length):
        """return np.ndarray"""
        X = np.linspace(0, limitation, _length).reshape((_length, 1));
        X = X.astype(np.float32);
        return X;

    def generateYValue(self, _data):
        Y = _data;
        """
        dy = 1.5 + 1.0 * np.random.random(Y.shape);
        noise = np.random.normal(0, dy);
        Y = Y + noise;
        Y = Y.astype(np.float32);
        """
        return Y;

    def generatexxValue(self, alpha, limitation, _length):
        """
        Mesh the input space for evaluations of the real function,
        the prediction and its MSE
        """
        xx = np.atleast_2d(np.linspace(0, limitation, _length * 10)).T;
        xx = xx.astype(np.float32);
        return xx;

    def regression(self, X, Y, xx, alpha):
        clf = GradientBoostingRegressor(loss = 'quantile', alpha = alpha,
                                        n_estimators = 250, max_depth = 3,
                                        learning_rate = .1, min_samples_leaf = 9,
                                        min_samples_split = 9);
        clf.fit(X, Y);
        """make the prediction on the meshed x-axis"""
        y_upper = clf.predict(xx);

        clf.set_params(alpha = 1.0 - alpha);
        clf.fit(X, Y);

        """make the prediction on the meshed x-axis"""
        y_lower = clf.predict(xx);
        clf.set_params(loss = 'ls');
        clf.fit(X, Y);

        """make the prediction on the meshed x-axis"""
        y_pred = clf.predict(xx);
        return (y_upper, y_lower, y_pred);

    def decisionTreeRegression(self, X, Y):
        rng = np.random.RandomState(1);
        regr_1 = DecisionTreeRegressor(max_depth=4);
        regr_2 = AdaBoostRegressor(DecisionTreeRegressor(max_depth=4), \
                                   n_estimators=300, random_state=rng);
        regr_1.fit(X, Y);
        regr_2.fit(X, Y);
        #predict
        y_1 = regr_1.predict(X);
        y_2 = regr_2.predict(X);
        return (y_1, y_2);

    def plotfigure(self, X, Y, xx, y_upper, y_lower, y_pred, y_1, y_2):
        plt.figure();
        #plt.plot(xx, self.predict(xx), 'g:', label = u'$f(x) = x\,\sin(x)$');
        plt.plot(X, Y, 'b.', markersize = 10, label = u'Obeservation');
        #plt.plot(xx, y_pred, 'r-', label=u'Prediction');
        plt.plot(xx, y_upper, 'k-');
        plt.plot(xx, y_lower, 'k-');
        plt.fill(np.concatenate([xx, xx[::-1]]),
                 np.concatenate([y_upper, y_lower[::-1]]),
                 alpha = .5, fc = 'b', ec = 'None',
                 label = '90% prediction interval');
        plt.plot(X, y_2, c = 'm', label='n_estimators=300', linewidth=2);
        plt.xlabel("time");
        plt.ylabel("magnitude")
        plt.legend(loc = 'upper left')
        plt.show()


if __name__ == '__main__':
    predictionIntervals = PredictionIntervalsForGradientBoostingRegression();


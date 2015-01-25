
using System;
using UnityEngine;

public class RoadLogic {
	private Car[] cars = new Car[16];

	public RoadLogic () {

	}



	/// 
	///        |NNt,NSf|
	///        |       |
	///        |NNf,NSt|
	/// -------         -------
	/// WEf,WEt         EEf,EEt
	/// WWt,WWf         EWt,EWf
	/// -------         -------
	///        |NNt,NSf|
	///        |       |
	///        |NNf,NSt|
	/// 
	public Car getCar(Direction at, Direction headed, bool front) {
		return cars[toArrayIndex(at, headed, front)];
	}

	///
	///        |NNt,NSf|
	///        |       |
	///        |NNf,NSt|
	/// -------         -------
	/// WEf,WEt         EEf,EEt
	/// WWt,WWf         EWt,EWf
	/// -------         -------
	///        |NNt,NSf|
	///        |       |
	///        |NNf,NSt|
	/// 
	public void setCar(Direction at, Direction headed, bool front, Car car) {
		int index = toArrayIndex (at, headed, front);
		if ((cars [index] != null && car != null)) {// || (cars[index] == null && car == null)) {
			Debug.Log("Overwriting car " + cars[index] + " with " + car + " in setCar!");
			throw new Exception("Overwriting car in setCar");
		}
		cars[toArrayIndex(at, headed, front)] = car;
		return;
	}

	public void setCar(Car.CarPosOnRoad cpor, Car car) {
		if (cpor.initial) {
			// initial pos can overlap other cars, so don't remove whatever else might be there
			return;
		}
		setCar (cpor.at, cpor.headed, cpor.front, car);
	}

	private int toArrayIndex(Direction at, Direction headed, bool front) {
		int atIdx = (int)at;
		int headedIdx = (int)headed;
		int frontIdx = (front) ? 1 : 0;
		if (atIdx != headedIdx && atIdx != (headedIdx + 2) % 4) {
			Debug.Log(String.Format("bad car position: {0} ({1}), {2} ({3}), {4} ({5})", at, atIdx, headed, headedIdx, front, frontIdx));
			return -1;
		}
		int result = atIdx * 4 + (headedIdx / 2) * 2 + frontIdx;
		return result;
	}
}



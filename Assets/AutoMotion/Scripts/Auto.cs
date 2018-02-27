using UnityEngine;
using System;
using System.Collections;

public delegate bool Predicate();
public delegate float Easer(float t);

public static class Auto
{
	#region Generic coroutines

	/// <summary>
	/// Interpolates a value between from and to, using the ease function.
	/// </summary>
	/// <param name="from">The value to interpolate from.</param>
	/// <param name="to">The value to interpolate to.</param>
	/// <param name="duration">The interpolation duration, in seconds.</param>
	/// <param name="ease">The ease function.</param>
	/// <param name="action">The action to perform with the interpolated value.</param>
	/// <returns>The IEnumerator for the coroutine.</returns>
	public static IEnumerator Interpolate(float from, float to, float duration, Easer ease, Action<float> action)
	{
		float elapsed = 0;
		float range = to - from;

		while (elapsed < duration)
		{
			elapsed = Mathf.MoveTowards(elapsed, duration, Time.deltaTime);
			action(from + range * ease(elapsed / duration));
			yield return 0;
		}

		action(from + range * ease(1));
	}

	/// <summary>
	/// Interpolates a value between from and to, using the ease function.
	/// </summary>
	/// <param name="from">The value to interpolate from.</param>
	/// <param name="to">The value to interpolate to.</param>
	/// <param name="duration">The interpolation duration, in seconds.</param>
	/// <param name="ease">The ease function.</param>
	/// <param name="action">The action to perform with the interpolated value.</param>
	/// <returns>The IEnumerator for the coroutine.</returns>
	public static IEnumerator Interpolate(float from, float to, float duration, EaseType ease, Action<float> action) =>
		Interpolate(from, to, duration, Ease.FromType(ease), action);

	/// <summary>
	/// Interpolates a Vector3 between from and to, using the ease function.
	/// </summary>
	/// <param name="from">The value to interpolate from.</param>
	/// <param name="to">The value to interpolate to.</param>
	/// <param name="duration">The interpolation duration, in seconds.</param>
	/// <param name="ease">The ease function.</param>
	/// <param name="action">The action to perform with the interpolated value.</param>
	/// <returns>The IEnumerator for the coroutine.</returns>
	public static IEnumerator Interpolate(Vector3 from, Vector3 to, float duration, Easer ease, Action<Vector3> action)
	{
		float elapsed = 0;
		Vector3 range = to - from;

		while (elapsed < duration)
		{
			elapsed = Mathf.MoveTowards(elapsed, duration, Time.deltaTime);
			action(from + range * ease(elapsed / duration));
			yield return 0;
		}

		action(from + range * ease(1));
	}

	/// <summary>
	/// Interpolates a Vector3 between from and to, using the ease function.
	/// </summary>
	/// <param name="from">The value to interpolate from.</param>
	/// <param name="to">The value to interpolate to.</param>
	/// <param name="duration">The interpolation duration, in seconds.</param>
	/// <param name="ease">The ease function.</param>
	/// <param name="action">The action to perform with the interpolated value.</param>
	/// <returns>The IEnumerator for the coroutine.</returns>
	public static IEnumerator Interpolate(Vector3 from, Vector3 to, float duration, EaseType ease, Action<Vector3> action) =>
		Interpolate(from, to, duration, Ease.FromType(ease), action);

	/// <summary>
	/// Interpolates a Quaternion between from and to, using the ease function.
	/// </summary>
	/// <param name="from">The value to interpolate from.</param>
	/// <param name="to">The value to interpolate to.</param>
	/// <param name="duration">The interpolation duration, in seconds.</param>
	/// <param name="ease">The ease function.</param>
	/// <param name="action">The action to perform with the interpolated value.</param>
	/// <returns>The IEnumerator for the coroutine.</returns>
	public static IEnumerator Interpolate(Quaternion from, Quaternion to, float duration, Easer ease, Action<Quaternion> action)
	{
		float elapsed = 0;

		while (elapsed < duration)
		{
			elapsed = Mathf.MoveTowards(elapsed, duration, Time.deltaTime);
			action(Quaternion.Lerp(from, to, ease(elapsed / duration)));
			yield return 0;
		}

		action(Quaternion.Lerp(from, to, ease(1)));
	}

	/// <summary>
	/// Interpolates a Quaternion between from and to, using the ease function.
	/// </summary>
	/// <param name="from">The value to interpolate from.</param>
	/// <param name="to">The value to interpolate to.</param>
	/// <param name="duration">The interpolation duration, in seconds.</param>
	/// <param name="ease">The ease function.</param>
	/// <param name="action">The action to perform with the interpolated value.</param>
	/// <returns>The IEnumerator for the coroutine.</returns>
	public static IEnumerator Interpolate(Quaternion from, Quaternion to, float duration, EaseType ease, Action<Quaternion> action) =>
		Interpolate(from, to, duration, Ease.FromType(ease), action);

	#endregion

	#region Transform coroutines

	public static IEnumerator MoveTo(this Transform transform, Vector3 target, float duration, Easer ease) =>
		Interpolate(transform.localPosition, target, duration, ease, v => transform.localPosition = v);

	public static IEnumerator MoveTo(this Transform transform, Vector3 target, float duration) =>
		Interpolate(transform.localPosition, target, duration, Ease.Linear, v => transform.localPosition = v);

	public static IEnumerator MoveTo(this Transform transform, Vector3 target, float duration, EaseType ease) =>
		Interpolate(transform.localPosition, target, duration, ease, v => transform.localPosition = v);

	public static IEnumerator MoveFrom(this Transform transform, Vector3 target, float duration, Easer ease) =>
		Interpolate(target, transform.localPosition, duration, ease, v => transform.localPosition = v);

	public static IEnumerator MoveFrom(this Transform transform, Vector3 target, float duration) =>
		Interpolate(target, transform.localPosition, duration, Ease.Linear, v => transform.localPosition = v);

	public static IEnumerator MoveFrom(this Transform transform, Vector3 target, float duration, EaseType ease) =>
		Interpolate(target, transform.localPosition, duration, ease, v => transform.localPosition = v);

	public static IEnumerator ScaleTo(this Transform transform, Vector3 target, float duration, Easer ease) =>
		Interpolate(transform.localScale, target, duration, ease, v => transform.localScale = v);

	public static IEnumerator ScaleTo(this Transform transform, Vector3 target, float duration) =>
		Interpolate(transform.localScale, target, duration, Ease.Linear, v => transform.localScale = v);

	public static IEnumerator ScaleTo(this Transform transform, Vector3 target, float duration, EaseType ease) =>
		Interpolate(transform.localScale, target, duration, ease, v => transform.localScale = v);

	public static IEnumerator ScaleFrom(this Transform transform, Vector3 target, float duration, Easer ease) =>
		Interpolate(target, transform.localScale, duration, ease, v => transform.localScale = v);

	public static IEnumerator ScaleFrom(this Transform transform, Vector3 target, float duration) =>
		Interpolate(target, transform.localScale, duration, Ease.Linear, v => transform.localScale = v);

	public static IEnumerator ScaleFrom(this Transform transform, Vector3 target, float duration, EaseType ease) =>
		Interpolate(target, transform.localScale, duration, ease, v => transform.localScale = v);

	public static IEnumerator RotateTo(this Transform transform, Quaternion target, float duration, Easer ease) =>
		Interpolate(transform.localRotation, target, duration, ease, v => transform.localRotation = v);

	public static IEnumerator RotateTo(this Transform transform, Quaternion target, float duration) =>
		Interpolate(transform.localRotation, target, duration, Ease.Linear, v => transform.localRotation = v);

	public static IEnumerator RotateTo(this Transform transform, Quaternion target, float duration, EaseType ease) =>
		Interpolate(transform.localRotation, target, duration, ease, v => transform.localRotation = v);

	public static IEnumerator RotateFrom(this Transform transform, Quaternion target, float duration, Easer ease) =>
		Interpolate(target, transform.localRotation, duration, ease, v => transform.localRotation = v);

	public static IEnumerator RotateFrom(this Transform transform, Quaternion target, float duration) =>
		Interpolate(target, transform.localRotation, duration, Ease.Linear, v => transform.localRotation = v);

	public static IEnumerator RotateFrom(this Transform transform, Quaternion target, float duration, EaseType ease) =>
		Interpolate(target, transform.localRotation, duration, ease, v => transform.localRotation = v);

	public static IEnumerator CurveTo(this Transform transform, Vector3 control, Vector3 target, float duration, Easer ease)
	{
		float elapsed = 0;
		var start = transform.localPosition;

		while (elapsed < duration)
		{
			elapsed = Mathf.MoveTowards(elapsed, duration, Time.deltaTime);
			float t = ease(elapsed / duration);
			transform.localPosition = start * (1 - t) * (1 - t) + control * 2 * (1 - t) * t + target * t * t;
			yield return 0;
		}

		transform.localPosition = target;
	}

	public static IEnumerator CurveTo(this Transform transform, Vector3 control, Vector3 target, float duration) =>
		CurveTo(transform, control, target, duration, Ease.Linear);

	public static IEnumerator CurveTo(this Transform transform, Vector3 control, Vector3 target, float duration, EaseType ease) =>
		CurveTo(transform, control, target, duration, Ease.FromType(ease));

	public static IEnumerator CurveFrom(this Transform transform, Vector3 control, Vector3 start, float duration, Easer ease)
	{
		var target = transform.localPosition;
		transform.localPosition = start;
		return CurveTo(transform, control, target, duration, ease);
	}

	public static IEnumerator CurveFrom(this Transform transform, Vector3 control, Vector3 start, float duration) =>
		CurveFrom(transform, control, start, duration, Ease.Linear);

	public static IEnumerator CurveFrom(this Transform transform, Vector3 control, Vector3 start, float duration, EaseType ease) =>
		CurveFrom(transform, control, start, duration, Ease.FromType(ease));

	public static IEnumerator Shake(this Transform transform, Vector3 amount, float duration)
	{
		var start = transform.localPosition;
		var shake = Vector3.zero;

		while (duration > 0)
		{
			duration -= Time.deltaTime;
			shake.Set(
				UnityEngine.Random.Range(-amount.x, amount.x),
				UnityEngine.Random.Range(-amount.y, amount.y),
				UnityEngine.Random.Range(-amount.z, amount.z)
			);
			transform.localPosition = start + shake;
			yield return 0;
		}

		transform.localPosition = start;
	}

	public static IEnumerator Shake(this Transform transform, float amount, float duration) =>
		Shake(transform, Vector3.one * amount, duration);

	#endregion

	#region Waiting coroutines

	public static IEnumerator Wait(float duration)
	{
		while (duration > 0)
		{
			duration -= Time.deltaTime;
			yield return 0;
		}
	}

	public static IEnumerator WaitUntil(Predicate predicate)
	{
		while (!predicate())
			yield return 0;
	}

	#endregion

	#region Time-based motion

	public static float Loop(float duration, float from, float to, float offsetPercent)
	{
		var range = to - from;
		var total = (Time.time + duration * offsetPercent) * (Mathf.Abs(range) / duration);

		return (range > 0) ?
			from + Time.time - (range * Mathf.FloorToInt((Time.time / range))) :
			from - (Time.time - (Mathf.Abs(range) * Mathf.FloorToInt((total / Mathf.Abs(range)))));
	}

	public static float Loop(float duration, float from, float to) =>
		Loop(duration, from, to, 0);

	public static Vector3 Loop(float duration, Vector3 from, Vector3 to, float offsetPercent) =>
		Vector3.Lerp(from, to, Loop(duration, 0, 1, offsetPercent));

	public static Vector3 Loop(float duration, Vector3 from, Vector3 to) =>
		Vector3.Lerp(from, to, Loop(duration, 0, 1));

	public static Quaternion Loop(float duration, Quaternion from, Quaternion to, float offsetPercent) =>
		Quaternion.Lerp(from, to, Loop(duration, 0, 1, offsetPercent));

	public static Quaternion Loop(float duration, Quaternion from, Quaternion to) =>
		Quaternion.Lerp(from, to, Loop(duration, 0, 1));

	public static float Wave(float duration, float from, float to, float offsetPercent)
	{
		var range = (to - from) / 2;
		return from + range + Mathf.Sin(((Time.time + duration * offsetPercent) / duration) * (Mathf.PI * 2)) * range;
	}

	public static float Wave(float duration, float from, float to) =>
		Wave(duration, from, to, 0);

	public static Vector3 Wave(float duration, Vector3 from, Vector3 to, float offsetPercent) =>
		Vector3.Lerp(from, to, Wave(duration, 0, 1, offsetPercent));

	public static Vector3 Wave(float duration, Vector3 from, Vector3 to) =>
		Vector3.Lerp(from, to, Wave(duration, 0, 1));

	public static Quaternion Wave(float duration, Quaternion from, Quaternion to, float offsetPercent) =>
		Quaternion.Lerp(from, to, Wave(duration, 0, 1, offsetPercent));

	public static Quaternion Wave(float duration, Quaternion from, Quaternion to) =>
		Quaternion.Lerp(from, to, Wave(duration, 0, 1));

	#endregion
}

#region Easing functions

public enum EaseType { Linear, QuadIn, QuadOut, QuadInOut, CubeIn, CubeOut, CubeInOut, BackIn, BackOut, BackInOut, ExpoIn, ExpoOut, ExpoInOut, SineIn, SineOut, SineInOut, ElasticIn, ElasticOut, ElasticInOut }

public static class Ease
{
	public static readonly Easer Linear = (t) => t;
	public static readonly Easer QuadIn = (t) => t * t;
	public static readonly Easer QuadOut = (t) => 1 - QuadIn(1 - t);
	public static readonly Easer QuadInOut = (t) => (t <= 0.5f) ? QuadIn(t * 2) / 2 : QuadOut(t * 2 - 1) / 2 + 0.5f;
	public static readonly Easer CubeIn = (t) => t * t * t;
	public static readonly Easer CubeOut = (t) => 1 - CubeIn(1 - t);
	public static readonly Easer CubeInOut = (t) => (t <= 0.5f) ? CubeIn(t * 2) / 2 : CubeOut(t * 2 - 1) / 2 + 0.5f;
	public static readonly Easer BackIn = (t) => t * t * (2.70158f * t - 1.70158f);
	public static readonly Easer BackOut = (t) => 1 - BackIn(1 - t);
	public static readonly Easer BackInOut = (t) => (t <= 0.5f) ? BackIn(t * 2) / 2 : BackOut(t * 2 - 1) / 2 + 0.5f;
	public static readonly Easer ExpoIn = (t) => (float)Mathf.Pow(2, 10 * (t - 1));
	public static readonly Easer ExpoOut = (t) => 1 - ExpoIn(t);
	public static readonly Easer ExpoInOut = (t) => t < .5f ? ExpoIn(t * 2) / 2 : ExpoOut(t * 2) / 2;
	public static readonly Easer SineIn = (t) => -Mathf.Cos(Mathf.PI / 2 * t) + 1;
	public static readonly Easer SineOut = (t) => Mathf.Sin(Mathf.PI / 2 * t);
	public static readonly Easer SineInOut = (t) => -Mathf.Cos(Mathf.PI * t) / 2f + .5f;
	public static readonly Easer ElasticIn = (t) => 1 - ElasticOut(1 - t);
	public static readonly Easer ElasticOut = (t) => Mathf.Pow(2, -10 * t) * Mathf.Sin((t - 0.075f) * (2 * Mathf.PI) / 0.3f) + 1;
	public static readonly Easer ElasticInOut = (t) => (t <= 0.5f) ? ElasticIn(t * 2) / 2 : ElasticOut(t * 2 - 1) / 2 + 0.5f;

	public static Easer FromType(EaseType type)
	{
		switch (type)
		{
			case EaseType.Linear: return Linear;
			case EaseType.QuadIn: return QuadIn;
			case EaseType.QuadOut: return QuadOut;
			case EaseType.QuadInOut: return QuadInOut;
			case EaseType.CubeIn: return CubeIn;
			case EaseType.CubeOut: return CubeOut;
			case EaseType.CubeInOut: return CubeInOut;
			case EaseType.BackIn: return BackIn;
			case EaseType.BackOut: return BackOut;
			case EaseType.BackInOut: return BackInOut;
			case EaseType.ExpoIn: return ExpoIn;
			case EaseType.ExpoOut: return ExpoOut;
			case EaseType.ExpoInOut: return ExpoInOut;
			case EaseType.SineIn: return SineIn;
			case EaseType.SineOut: return SineOut;
			case EaseType.SineInOut: return SineInOut;
			case EaseType.ElasticIn: return ElasticIn;
			case EaseType.ElasticOut: return ElasticOut;
			case EaseType.ElasticInOut: return ElasticInOut;
		}
		return Linear;
	}
}

#endregion

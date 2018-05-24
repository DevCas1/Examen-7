using System;
using UnityEngine;
using DG.Tweening;

namespace Sjouke.Simple.DOTween
{

    [Serializable]
    public sealed class Settings
    {
        public float MoveDuration;
        [Space(10)]
        public Vector3 JumpMoveVector;
        public float JumpMoveDuration;
        [Space(10)]
        public Vector3 TransformMoveOffset;
        [Space(10)]
        public float ResizeDuration;
        public Vector3 SizeIncrement;
        public float SizeJumpDuration;
        [Space(10)]
        public float RecolorDuration;
    }

    public class DOTweenAnimator : MonoBehaviour
    {
        public UnityEngine.Camera MenuCamera;
        public Settings Settings;
        private Vector3 _originalPos;
        private Vector3 _originalScale;
        private MeshRenderer _meshRenderer;
        private Material _originalSharedMat;

        private void OnEnable()
        {
            _originalPos = transform.localPosition;
            _originalScale = transform.localScale;
            _meshRenderer = GetComponent<MeshRenderer>();
            if (_meshRenderer != null)
                _originalSharedMat = _meshRenderer.sharedMaterial;
        }

        public void MoveX(float addition) => transform.DOBlendableLocalMoveBy(new Vector3(addition, 0, 0), Settings.MoveDuration);

        public void MoveY(float addition) => transform.DOBlendableLocalMoveBy(new Vector3(0, addition, 0), Settings.MoveDuration);

        public void MoveZ(float addition) => transform.DOBlendableMoveBy(new Vector3(0, 0, addition), Settings.MoveDuration);

        public void JumpMove() => transform.DOBlendableLocalMoveBy(Settings.JumpMoveVector.normalized, Settings.JumpMoveDuration).OnComplete(transform.DOBlendableMoveBy(-Settings.JumpMoveVector.normalized,
                                                                                                                                                                          Settings.JumpMoveDuration).Complete);

        public void MoveToTransorm(Transform target) => transform.DOBlendableLocalMoveBy(transform.InverseTransformPoint(target.position) + Settings.TransformMoveOffset, Settings.MoveDuration);

        public void MoveTowardsCamera(float factor)
        {
            try
            {
                transform.DOBlendableLocalMoveBy((MenuCamera.transform.position - transform.position).normalized * factor, Settings.MoveDuration);
            }
            catch (Exception e)
            {
                Debug.Log($"DOTweenAnimator on {transform.name} (MoveFromCamera): {e.Message}");
            }
        }

        public void ReturnToOrigin() => transform.DOLocalMove(_originalPos, Settings.MoveDuration);

        public void Resize(float size) => transform.DOBlendableScaleBy(new Vector3(size, size, size), Settings.ResizeDuration);

        public void JumpSize() => transform.DOScale(_originalScale + Settings.SizeIncrement, Settings.SizeJumpDuration).OnComplete(() => { ResetSize(); });

        public void ResetSize(bool instantly = true) => transform.DOScale(_originalScale, instantly ? 0 : Settings.ResizeDuration);

        public void SetColor(string newColorHex)
        {
            try
            {
                Color newColor;
                ColorUtility.TryParseHtmlString(newColorHex, out newColor);
                _meshRenderer.sharedMaterial.DOBlendableColor(newColor, Settings.RecolorDuration);
            }
            catch (Exception e)
            {
                Debug.Log($"DOTweenAnimator on {transform.name} (SetColor): {e.Message}");
            }
        }

        public void ResetColor(bool instantly = true)
        {
            try
            {
                _meshRenderer.sharedMaterial.DOColor(_originalSharedMat.color, instantly ? 0 : Settings.RecolorDuration);
            }
            catch (Exception e)
            {
                Debug.Log($"DOTweenAnimator on {transform.name} (ResetColor): {e.Message}");
            }
        }
    }
}
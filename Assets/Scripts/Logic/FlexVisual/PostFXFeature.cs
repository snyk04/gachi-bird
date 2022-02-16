using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace GachiBird.FlexVisual
{
    public class PostFXFeature : ScriptableRendererFeature
    {
        private class RenderPass : ScriptableRenderPass
        {
            public RenderTargetIdentifier Source;

            private readonly Material _material;
            private readonly Func<bool> _isActiveProvider;
            private RenderTargetHandle _temporaryTexture;
            
            public bool IsActive { get; set; }

            public RenderPass(Material material, Func<bool> isActiveProvider)
            {
                _material = material;
                _isActiveProvider = isActiveProvider;
            }
            
            public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
            {
                if (!_isActiveProvider())
                {
                    return;
                }
                
                CommandBuffer cmd = CommandBufferPool.Get(nameof(PostFXFeature));

                RenderTextureDescriptor cameraTextureDescriptor = renderingData.cameraData.cameraTargetDescriptor;
                cameraTextureDescriptor.depthBufferBits = 0;

                cmd.GetTemporaryRT(_temporaryTexture.id, cameraTextureDescriptor, FilterMode.Bilinear);

                Blit(cmd, Source, _temporaryTexture.Identifier(), _material);
                Blit(cmd, _temporaryTexture.Identifier(), Source);

                context.ExecuteCommandBuffer(cmd);
                CommandBufferPool.Release(cmd);
            }

            public override void FrameCleanup(CommandBuffer cmd)
            {
                if (!_isActiveProvider())
                {
                    return;
                }

                cmd.ReleaseTemporaryRT(_temporaryTexture.id);
            }
        }
        
#nullable disable
        [SerializeField] private Material _material;
        [SerializeField] private RenderPassEvent _renderPassEvent = RenderPassEvent.AfterRendering;
#nullable enable

        private RenderPass? _renderPass;

        public bool IsActive;

        public override void Create()
        {
            _renderPass = new RenderPass(_material, () => IsActive)
            {
                // Configures where the render pass should be injected.
                renderPassEvent = _renderPassEvent
            };
        }

        // Here you can inject one or multiple render passes in the renderer.
        // This method is called when setting up the renderer once per-camera.
        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            _renderPass!.Source = renderer.cameraColorTarget;
            renderer.EnqueuePass(_renderPass);
        }
    }
}

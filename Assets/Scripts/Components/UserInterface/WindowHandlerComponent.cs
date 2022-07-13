#nullable enable
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AreYouFruits.Common.ComponentGeneration;
using GachiBird.Game;
using GachiBird.UserInterface.Windows;
using UnityEngine;

namespace GachiBird.UserInterface
{
    // todo
    public class WindowHandler : IWindowHandler
    {
        public event Action<IWindow>? OnWindowShow;
        public event Action<IWindow>? OnWindowHide;

        private readonly IGameCycle _gameCycle;
        private readonly IReadOnlyDictionary<Type, IWindow> _windowsByTypes;

        public WindowHandler(IGameCycle gameCycle, IWindow[] windows)
        {
            _gameCycle = gameCycle;

            _windowsByTypes = new ReadOnlyDictionary<Type, IWindow>(
                windows.ToDictionary(window => window.GetType(), window => window)
            );

            _gameCycle.OnGameStart += ShowWindow<ScoreWindow>;
            _gameCycle.OnGameStart += HideWindow<PreStartWindow>;
            _gameCycle.OnGameEnd += ShowWindow<GameOverWindow>;
            _gameCycle.OnGameEnd += HideWindow<ScoreWindow>;
        }

        public void Start()
        {
            ShowWindow<PreStartWindow>();
        }

        public void ShowWindow<TWindow>()
            where TWindow : IWindow
        {
            IWindow window = _windowsByTypes[typeof(TWindow)];
            window.Show();
            OnWindowShow?.Invoke(window);
        }

        public void HideWindow<TWindow>()
            where TWindow : IWindow
        {
            IWindow window = _windowsByTypes[typeof(TWindow)];
            window.Hide();
            OnWindowShow?.Invoke(window);
        }
    }
    
    public class WindowHandlerComponent : AbstractComponent<WindowHandler>
    {
    #nullable disable
        [SerializeField] private SerializedInterface<IComponent<IGameCycle>> _gameCycle;
        [SerializeField] private SerializedInterface<IComponent<IWindow>>[] _windows;
    #nullable enable

        protected override WindowHandler Create()
        {
            var item = new WindowHandler(_gameCycle.GetHeldItem(), _windows.ExtractAsArray());

            item.Start();
            
            return item;
        }
    }
}

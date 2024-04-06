using PixelGunCheat.util;
using UnityEngine;
using Renderer = PixelGunCheat.util.Renderer;

namespace PixelGunCheat.modules.impl.arbitrary
{
    public class CheatModuleHud : CheatModuleArbitrary
    {
        private bool _downDown = false;
        private bool _upDown = false;
        private bool _rightDown = false;
        private bool _leftDown = false;
        
        private ICheatModule[] modules;
        private int selected = 0;
        private float maxY;
        private bool open = true;

        private HSVColor _gay = HSVColor.FromRGB(1, 0, 1);
        public CheatModuleHud(KeyCode k) : base(k)
        {
        }

        public void registerModules(params ICheatModule[] cheatModules)
        {
            modules = cheatModules;
        }

        public override string GetName()
        {
            return "HUD";
        }

        public override void HandleCheat(GameObject g = null)
        {
            _gay.Hue+=0.1f;
            if (_gay.Hue > 360) _gay.Hue = 0;
            
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (!_downDown)
                {
                    _downDown = true;
                    selected++;
                    if (selected > modules.Length - 1) selected = 0;
                }
            }
            else
            {
                _downDown = false;
            }
            
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (!_upDown)
                {
                    _upDown = true;
                    selected--;
                    if (selected < 0) selected = modules.Length - 1;
                }
            }
            else
            {
                _upDown = false;
            }
            
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (!_rightDown)
                {
                    _rightDown = true;
                    modules[selected].ToggleModule();
                }
            }
            else
            {
                _rightDown = false;
            }
            
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (!_leftDown)
                {
                    _leftDown = true;
                    open = !open;
                }
            }
            else
            {
                _leftDown = false;
            }

            foreach (var module in modules)
            {
                if (Input.GetKeyDown(module.GetKey()))
                {
                    module.ToggleModule();
                }
            }

            if (!open)
            {
                Renderer.SetFontSize(Renderer.ScaleValInt(24));
                Renderer.DrawSquare(new Vector2(20, 22), new Vector2(Renderer.ScaleValInt(280), Renderer.ScaleValInt(30)), new Color(0, 0,0, 0.75f));
                Renderer.DrawStringShadow(new Vector2(25, 23), "Left Arrow - Open Menu", _gay.AsARGB(1), false);
                return;
            }
            
            Renderer.SetFontSize(Renderer.ScaleValInt(32));
            Renderer.DrawSquare(new Vector2(20, 22), new Vector2(Renderer.ScaleValInt(505), Renderer.ScaleValInt(70)), new Color(0, 0,0, 0.75f));
            Renderer.DrawStringShadow(new Vector2(25, 25), "BoyKisserCentral (build ':3')", _gay.AsARGB(1), false);
            Renderer.SetFontSize(Renderer.ScaleValInt(24));
            Renderer.DrawStringShadow(new Vector2(25, 25 + Renderer.ScaleValInt(34)), "github.com/stanuwu & github.com/hiderikzki", _gay.AsARGB(1), false);
            Renderer.SetFontSize(Renderer.ScaleValInt(20));
            
            float height = maxY + Renderer.ScaleValInt(15);
            Renderer.DrawSquare(new Vector2(20, 150 + Renderer.ScaleValInt(20)), new Vector2(Renderer.ScaleValFloat(350), height), new Color(0, 0,0, 0.75f));
            
            float offset = 150 + Renderer.ScaleValInt(35);
            int index = 0;
            
            foreach (var module in modules)
            {
                var content = new GUIContent(module.GetName());
                var size = Renderer.StringStyle.CalcSize(content);
                var keybind = new GUIContent("(" + module.GetKey() + ")");
                var keybind_size = Renderer.StringStyle.CalcSize(keybind);
                
                if (index == selected)
                {
                    Renderer.DrawStringShadow(new Vector2(28, offset), ">", Color.magenta, false);
                    Renderer.DrawStringShadow(new Vector2(28 + Renderer.ScaleValInt(19), offset), "(" + module.GetKey() + ")", Color.cyan, false);
                    Renderer.DrawStringShadow(new Vector2(28 + keybind_size.x + Renderer.ScaleValInt(23), offset), module.GetName(), module.IsEnabled() ? _gay.AsARGB(1) : Color.gray, false);
                }
                else
                {
                    Renderer.DrawStringShadow(new Vector2(10 + Renderer.ScaleValInt(19), offset), "(" + module.GetKey() + ")", Color.cyan, false);
                    Renderer.DrawStringShadow(new Vector2(10 + keybind_size.x + Renderer.ScaleValInt(23), offset), module.GetName(), module.IsEnabled() ? _gay.AsARGB(1) : Color.gray, false);
                }
                
                offset += size.y;
                index++;
            }

            maxY = offset - 180;
        }
    }
}
﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 *	
 *  Maintain State For UI Stack
 *
 *	by Xuanyi
 *
 */

namespace MoleMole
{
    public class ContextManager
    {
        private Stack<BaseContext> _contextStack = new Stack<BaseContext>();

        private ContextManager()
        {
            Push(new MainMenuContext());
        }

        public void Push(BaseContext nextContext)
        {

            if (_contextStack.Count != 0)
            {
                BaseContext curContext = _contextStack.Peek();
                BaseView curView = Singleton<UIManager>.Instance.GetSingleUI(curContext.ViewType).GetComponent<BaseView>();
                curView.OnExit(curContext);
            }

            _contextStack.Push(nextContext);
            BaseView nextView = Singleton<UIManager>.Instance.GetSingleUI(nextContext.ViewType).GetComponent<BaseView>();
            nextView.OnEnter(nextContext);
        }

        public void Pop()
        {
            if (_contextStack.Count != 0)
            {
                BaseContext curContext = _contextStack.Peek();
                _contextStack.Pop();

                BaseView curView = Singleton<UIManager>.Instance.GetSingleUI(curContext.ViewType).GetComponent<BaseView>();
                curView.OnExit(curContext);
                Singleton<UIManager>.Instance.DestroySingleUI(curContext.ViewType);
            }

            if (_contextStack.Count != 0)
            {
                BaseContext lastContext = _contextStack.Peek();
                BaseView curView = Singleton<UIManager>.Instance.GetSingleUI(lastContext.ViewType).GetComponent<BaseView>();
                curView.OnEnter(lastContext);
            }
        }

        public BaseContext PeekOrNull()
        {
            if (_contextStack.Count != 0)
            {
                return _contextStack.Peek();
            }
            return null;
        }
    }
}

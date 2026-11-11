import type { ReactNode } from 'react'

type StoreLayoutProps = {
  children: ReactNode
}

export default function StoreLayout({ children }: StoreLayoutProps) {
  return (
    <>
      <header className="store-header">
        <a href="/">Möbelo</a>
      </header>

      <main className="store-main">{children}</main>

      <footer className="store-footer">Möbelo</footer>
    </>
  )
}
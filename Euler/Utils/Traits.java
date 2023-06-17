package utils;

import java.applet.Applet;
import java.awt.BasicStroke;
import java.awt.Checkbox;
import java.awt.CheckboxGroup;
import java.awt.Choice;
import java.awt.Color;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Image;
import java.awt.Label;
import java.awt.RenderingHints;
import java.awt.Scrollbar;
import java.awt.event.AdjustmentEvent;
import java.awt.event.AdjustmentListener;
import java.awt.event.ItemEvent;
import java.awt.event.ItemListener;
import java.text.DecimalFormat;

public class Traits extends Applet implements ItemListener, AdjustmentListener {
	private static long serialVersionUID = 1420972181089577L;
	private Font font = new Font("SansSerif", 1, 12);
	private Font small = new Font("Serif", 0, 9);
	private Image ima;
	private Graphics h;
	private int la, ha;
	private FlowLayout fl = null;
	private CheckboxGroup bg1 = new CheckboxGroup();
	private Checkbox cb1, cb2;
	private Label lbcap = new Label("Cap", 1);
	private Choice chcap = new Choice();
	private Label lbjoin = new Label("Join", 1);
	private Choice chjoin = new Choice();
	private Label lblar = new Label("Largeur = 2", 1);
	private Scrollbar scl = new Scrollbar(0, 20, 10, 10, 110);
	private Choice chpoint = new Choice();
	private Checkbox cb3;
	private int[] Tcap = { 0, 1, 2 }, Tjoin = { 0, 1, 2 };
	private int cap, join, tiret;
	private Object cren;
	private float motif[][] = { { 8.0f, 4.0f }, { 20.0f, 4.0f },
			{ 10.0f, 2.0f, 2f, 2f }, { 15.0f, 2.0f, 8f, 2f, 5.0f, 2.0f } };
	private float lar = 2.0f;
	private BasicStroke stroke = new BasicStroke(this.lar, 0, 0);
	private BasicStroke normal = new BasicStroke();
	private DecimalFormat f10 = new DecimalFormat("0.0");
	private bool anticren = false, continu = true;
	private int xMin;
	private int xMax;
	private int yMin;
	private int yMax;
	private int deltaX;

	@Override
	public void init() {
		this.resize(1500, 1000);
		this.setBackground(Color.lightGray);
		this.setFont(this.font);
		this.la = this.getWidth();
		this.ha = this.getHeight();
		this.xMin = 20;
		this.xMax = this.la - 20;
		this.yMin = 50;
		this.yMax = this.ha - 20;
		this.deltaX = this.xMax - this.xMin;
		this.ima = this.createImage(this.la, this.ha);
		this.h = this.ima.getGraphics();
		this.setLayout(this.fl);
		this.Add(this.cb1 = new Checkbox("Continu", this.bg1, true));
		this.cb1.addItemListener(this);
		this.cb1.setBounds(20, 5, 80, 20);
		this.Add(this.cb2 = new Checkbox("Pointillés", this.bg1, false));
		this.cb2.addItemListener(this);
		this.cb2.setBounds(20, 25, 80, 20);
		this.Add(this.lbcap);
		this.lbcap.setBounds(100, 3, 110, 18);
		this.chcap.addItem("CAP_BUTT");
		this.chcap.addItem("CAP_ROUND");
		this.chcap.addItem("CAP_SQUARE");
		this.Add(this.chcap);
		this.chcap.addItemListener(this);
		this.chcap.setBackground(Color.lightGray);
		this.chcap.setBounds(100, 22, 110, 20);
		this.Add(this.lbjoin);
		this.lbjoin.setBounds(220, 3, 110, 18);
		this.chjoin.addItem("JOIN_MITTER");
		this.chjoin.addItem("JOIN_ROUND");
		this.chjoin.addItem("JOIN_BEVEL");
		this.Add(this.chjoin);
		this.chjoin.addItemListener(this);
		this.chjoin.setBackground(Color.lightGray);
		this.chjoin.setBounds(220, 22, 110, 20);
		this.Add(this.lblar);
		this.lblar.setBounds(340, 3, 100, 18);
		this.Add(this.scl);
		this.scl.setBounds(340, 23, 100, 15);
		this.scl.addAdjustmentListener(this);
		this.scl.setBackground(Color.gray);
		this.Add(this.cb3 = new Checkbox("Anticrénelage", false));
		this.cb3.addItemListener(this);
		this.cb3.setBounds(460, 3, 100, 20);
		this.chpoint.addItem("Tirets 1");
		this.chpoint.addItem("Tirets 2");
		this.chpoint.addItem("Tirets 3");
		this.chpoint.addItem("Tirets 4");
		this.Add(this.chpoint);
		this.chpoint.setBounds(460, 25, 100, 20);
		this.chpoint.setBackground(Color.lightGray);
		this.chpoint.addItemListener(this);
		this.initStroke();
	}

	@Override
	public void itemStateChanged(ItemEvent evt) {
		if (evt.getSource() == this.cb1) {
			this.continu = true;
		} else if (evt.getSource() == this.cb2) {
			this.continu = false;
		} else if (evt.getSource() == this.chcap) {
			this.cap = this.Tcap[this.chcap.getSelectedIndex()];
		} else if (evt.getSource() == this.chjoin) {
			this.join = this.Tjoin[this.chjoin.getSelectedIndex()];
		} else if (evt.getSource() == this.cb3) {
			this.anticren = !this.anticren;
		} else if (evt.getSource() == this.chpoint) {
			this.tiret = this.chpoint.getSelectedIndex();
		}
		this.initStroke();
		this.repaint();
	}

	@Override
	public void adjustmentValueChanged(AdjustmentEvent evt) {
		if (evt.getSource() == this.scl) {
			this.lar = (float) (this.scl.getValue() / 10.);
			this.lblar.setText("Largeur = " + this.f10.format(this.lar));
			this.initStroke();
		}
		this.repaint();
	}

	public void initStroke() {
		if (this.continu) {
			this.stroke = new BasicStroke(this.lar, this.cap, this.join);
		} else {
			this.stroke = new BasicStroke(this.lar, this.cap, this.join, 10.f,
					this.motif[this.tiret], 0);
		}
		if (this.anticren) {
			this.cren = RenderingHints.VALUE_ANTIALIAS_ON;
		} else {
			this.cren = RenderingHints.VALUE_ANTIALIAS_OFF;
		}
	}

	public void cadre3D(int x, int y, int w, int z) {
		Color blanc = new Color(230, 230, 230), gris = new Color(130,
				130, 130);
		this.h.setColor(gris);
		this.h.drawLine(x, y, w, y);
		this.h.drawLine(x, y + 1, w - 1, y + 1);
		this.h.drawLine(x, y, x, z);
		this.h.drawLine(x + 1, y, x + 1, z - 1);
		this.h.setColor(blanc);
		this.h.drawLine(x, z, w, z);
		this.h.drawLine(w, y + 1, w, z);
		this.h.drawLine(x + 1, z - 1, w, z - 1);
		this.h.drawLine(w - 1, y + 2, w - 1, z);
	}

	@Override
	public void update(Graphics g) {
		this.paint(g);
	}

	@Override
	public void paint(Graphics g) {
		this.h.setColor(Color.lightGray);
		this.h.fillRect(0, 0, this.la, this.ha);
		this.h.setColor(Color.black);
		this.h.drawRect(0, 0, this.la - 1, this.ha - 1);
		this.h.setFont(this.small);
		this.h.drawString("jjR 01-2012", 25, this.ha - 25);
		Graphics2D g2 = (Graphics2D) this.h;
		g2.setStroke(this.stroke);
		g2.setRenderingHint(RenderingHints.KEY_ANTIALIASING, this.cren);

		int pas = 30;

		//		for (int i = this.xMin; i <= this.xMax; i += pas) {
		//			this.h.drawLine(i, this.yMin, i, this.yMax);
		//		}
		//		for (int j = this.yMin; j <= this.yMax; j += pas) {
		//			this.h.drawLine(this.xMin, j, this.xMax, j);
		//		}
		int deltaY = this.yMax - this.yMin;
		for (int k = -3; k <= 3; k++) {
			// delta[i] : y = tan(alpha) * x + (pas / cos(alpha) ) * i + yMin
			double alpha = k * Math.PI / 8;
			double m = Math.tan(alpha);
			double pasDroite = pas / Math.cos(alpha);
			double borne = deltaY + this.deltaX * m;
			for (double p = -borne; p <= borne; p += pasDroite) {
				this.drawLine(m, this.yMin + p);
				//				this.drawLine(m, this.yMin - p);
				//				this.drawLine(-m, this.yMin + p);
				//				this.drawLine(-m, this.yMin - p);
			}

		}

		g2.setRenderingHint(RenderingHints.KEY_ANTIALIASING,
				RenderingHints.VALUE_ANTIALIAS_OFF);
		g2.setStroke(this.normal);
		this.cadre3D(this.xMin, this.yMin, this.xMax, this.yMax);
		g.drawImage(this.ima, 0, 0, this);
		this.showStatus("J. J. Rousseau 01-2012");
	}

	private void drawLine(double m, double p) {
		int x1 = this.xMin;
		int x2 = this.xMax;
		int y1 = (int) p;
		int y2 = (int) (m * this.deltaX + p);
		if (y1 < this.yMin) {
			y1 = this.yMin;
			x1 = (int) ((this.yMin - p) / m);
		}
		if (y2 < this.yMin) {
			y2 = this.yMin;
			x2 = (int) ((this.yMin - p) / m);
		}
		if (y2 > this.yMax) {
			y2 = this.yMax;
			x2 = (int) ((this.yMax - p) / m);
		}
		if (y1 > this.yMax) {
			y1 = this.yMax;
			x1 = (int) ((this.yMax - p) / m);
		}
		this.h.drawLine(x1, y1, x2, y2);
	}

	@Override
	public void destroy() {
		this.h.dispose();
		this.ima.flush();
	}
}
